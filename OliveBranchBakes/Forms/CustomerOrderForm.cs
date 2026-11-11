using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Navigation;
using OliveBranchBakes.Services;
using System.ComponentModel;
using System.Drawing;

namespace OliveBranchBakes.Forms;

/// <summary>Displays bakery products and the current shopping cart.</summary>
public partial class CustomerOrderForm : Form
{
    private CatalogService? _catalog;
    private Panel? _scrollableMenu;
    private bool _resizingMenu;
    private bool _fittingCards;
    private bool _fittingBasket;
    private Panel? _cartList;
    private Label? _cartSubtotal;
    private Button? _clearCart;
    private DateTimePicker? _menuDate;

    private sealed class MenuFilterOption
    {
        public string Label { get; }
        public string? CategoryId { get; }
        public bool IsSeasonal { get; }

        public MenuFilterOption(string label, string? categoryId = null, bool isSeasonal = false)
        {
            Label = label;
            CategoryId = categoryId;
            IsSeasonal = isSeasonal;
        }

        public override string ToString() => Label;
    }

    public CustomerOrderForm()
    {
        InitializeComponent();
        // Replace the designer's sample cards only when the application runs.
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            LoadPreviewImages();
            return;
        }

        SetupLiveCatalog();
    }

    private void SetupLiveCatalog()
    {
        try
        {
            _catalog = new CatalogService(AppData.Store);

            catalogCard.SuspendLayout();
            foreach (Panel sample in new[] { product0, product1, product2, product3 })
            {
                catalogCard.Controls.Remove(sample);
                sample.Dispose();
            }

            _scrollableMenu = new Panel
            {
                Name = "jsonMenuList",
                Location = new Point(15, 62),
                Size = new Size(654, 387),
                AutoScroll = true,
                BackColor = Color.FromArgb(255, 253, 249),
                TabIndex = 6
            };
            catalogCard.Controls.Add(_scrollableMenu);
            catalogCard.SizeChanged += (_, _) => UpdateMenuLayout();
            _scrollableMenu.SizeChanged += (_, _) => FitProductCards();
            catalogCard.ResumeLayout(true);
            UpdateMenuLayout();

            pageSubtitle.Text = "Choose your baked goods, adjust quantities, and review your cart.";
            ConfigureCart();
            ConfigureMenuDate();
            menuBadge.Text = "BAKERY MENU";

            categoryFilter.Items.Clear();
            categoryFilter.Items.Add(new MenuFilterOption("All baked goods"));
            foreach (BakeryCategory category in _catalog.Categories())
                categoryFilter.Items.Add(new MenuFilterOption(category.Name, category.Id));
            categoryFilter.Items.Add(new MenuFilterOption("Seasonal", isSeasonal: true));

            categoryFilter.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;
            categoryFilter.SelectedIndex = 0;
            RenderCart();
        }
        catch (Exception ex)
        {
            categoryFilter.Enabled = false;
            menuBadge.Text = "MENU UNAVAILABLE";
            catalogHeading.Text = "Unable to load saved menu";
            EnglishDialog.Show(this,
                "The saved bakery menu could not be loaded.\n\n" + ex.Message +
                "\n\nCheck the JSON files in the Phase3A data folder.",
                "Menu load error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void CategoryFilter_SelectedIndexChanged(object? sender, EventArgs e) => RenderFilteredProducts();

    private void RenderFilteredProducts()
    {
        if (_catalog is null || _scrollableMenu is null) return;
        var filter = categoryFilter.SelectedItem as MenuFilterOption;
        if (filter is null) return;

        IReadOnlyList<BakeryProduct> products = _catalog.AvailableOn(AppData.Cart.MenuDate, filter.CategoryId);
        if (filter.IsSeasonal)
            products = products.Where(p => p.IsSeasonal).ToList();

        catalogHeading.Text = filter.CategoryId is null && !filter.IsSeasonal
            ? $"Bakery menu — {AppData.Cart.MenuDate:MMM d, yyyy}"
            : filter.Label + " selection";
        menuBadge.Text = $"{products.Count} AVAILABLE";

        _scrollableMenu.SuspendLayout();
        // Release images and controls from the previous category.
        foreach (Control oldCard in _scrollableMenu.Controls.Cast<Control>().ToArray())
        {
            _scrollableMenu.Controls.Remove(oldCard);
            oldCard.Dispose();
        }
        _scrollableMenu.AutoScrollPosition = Point.Empty;

        if (products.Count == 0)
        {
            Label empty = new()
            {
                Location = new Point(12, 18),
                Size = new Size(592, 120),
                Text = filter.IsSeasonal
                    ? "No seasonal items are available today. Seasonal products appear here only during their listed dates."
                    : "No products are available in this category today. Try another category.",
                ForeColor = Color.FromArgb(105, 75, 54),
                Font = new Font("Segoe UI", 11f),
                TextAlign = ContentAlignment.MiddleLeft
            };
            _scrollableMenu.Controls.Add(empty);
            _scrollableMenu.AutoScrollMinSize = new Size(0, 150);
        }
        else
        {
            for (int i = 0; i < products.Count; i++)
                _scrollableMenu.Controls.Add(CreateProductCard(products[i], i * 98));
            _scrollableMenu.AutoScrollMinSize = new Size(0, products.Count * 98);
        }

        _scrollableMenu.ResumeLayout(true);
        UpdateMenuLayout();
    }

    // The catalog frame is resized by the page layout. Keep its product list inside
    // that frame instead of leaving the list at its original design-time size.
    internal void UpdateMenuLayout()
    {
        if (_resizingMenu || _scrollableMenu is null || _scrollableMenu.IsDisposed)
            return;

        _resizingMenu = true;
        try
        {
            int margin = Math.Max(12, (int)Math.Round(catalogCard.ClientSize.Width * 15f / 688f));
            int top = Math.Max(61, catalogHeading.Bottom + 7);
            int availableWidth = Math.Max(200, catalogCard.ClientSize.Width - 2 * margin);
            int availableHeight = Math.Max(140, catalogCard.ClientSize.Height - top - margin);
            _scrollableMenu.SetBounds(margin, top, availableWidth, availableHeight);
            FitProductCards();
            UpdateBasketLayout();
        }
        finally
        {
            _resizingMenu = false;
        }
    }

    private void FitProductCards()
    {
        if (_fittingCards || _scrollableMenu is null || _scrollableMenu.IsDisposed)
            return;

        _fittingCards = true;
        try
        {
            // Size the images and text using the actual menu viewport, rather than
            // the initial 654 x 387 placeholder used by the Phase 2 design.
            float widthRatio = _scrollableMenu.ClientSize.Width / 654f;
            float heightRatio = _scrollableMenu.ClientSize.Height / 387f;
            float rowScale = Math.Clamp(MathF.Sqrt(widthRatio * heightRatio), .85f, 1.75f);
            float textScale = Math.Clamp(rowScale, .9f, 1.6f);
            int width = Math.Max(200, _scrollableMenu.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4);
            int rowHeight = (int)Math.Round(91 * rowScale);
            int spacing = (int)Math.Round(98 * rowScale);
            int index = 0;
            _scrollableMenu.SuspendLayout();
            foreach (Control card in _scrollableMenu.Controls)
            {
                if (card is not Panel)
                {
                    card.Width = Math.Max(200, width - 12);
                    continue;
                }

                card.SuspendLayout();
                card.SetBounds(0, index++ * spacing, width, rowHeight);
                int image = (int)Math.Round(76 * rowScale);
                int imageX = (int)Math.Round(8 * rowScale);
                int imageY = (rowHeight - image) / 2;
                int left = imageX + image + (int)Math.Round(15 * rowScale);
                int buttonW = (int)Math.Round(86 * textScale);
                int buttonH = (int)Math.Round(48 * rowScale);
                int margin = Math.Max(10, (int)Math.Round(10 * textScale));
                int buttonX = width - buttonW - margin;
                int priceW = (int)Math.Round(90 * textScale);
                int priceX = buttonX - priceW - margin;
                int labelW = Math.Max(100, priceX - left - 8);
                foreach (Control part in card.Controls)
                {
                    switch (part.Name)
                    {
                        case "itemImage":
                            part.SetBounds(imageX, imageY, image, image); break;
                        case "itemName":
                            part.SetBounds(left, (int)(10 * rowScale), labelW, (int)(32 * rowScale)); break;
                        case "itemDescription":
                            part.SetBounds(left, (int)(43 * rowScale), labelW, (int)(28 * rowScale)); break;
                        case "itemPrice":
                            part.SetBounds(priceX, (int)(10 * rowScale), priceW, (int)(29 * rowScale)); break;
                        case "itemAdd":
                            part.SetBounds(buttonX, (rowHeight - buttonH) / 2, buttonW, buttonH); break;
                    }
                    if (part is Label or Button)
                    {
                        float desired = part.Name switch
                        {
                            "itemName" => 10.7f * textScale,
                            "itemDescription" => 9.2f * textScale,
                            "itemPrice" => 10.5f * textScale,
                            _ => 10f * textScale
                        };
                        if (Math.Abs(part.Font.SizeInPoints - desired) > .15f)
                        {
                            Font oldFont = part.Font;
                            part.Font = new Font("Segoe UI", desired, oldFont.Style);
                            oldFont.Dispose();
                        }
                    }
                }
                card.ResumeLayout(true);
            }
            _scrollableMenu.AutoScrollMinSize = new Size(0, index * spacing);
            _scrollableMenu.ResumeLayout(true);
        }
        finally
        {
            _fittingCards = false;
        }
    }

    private Panel CreateProductCard(BakeryProduct product, int y)
    {
        Color olive = Color.FromArgb(55, 73, 44);
        Color brown = Color.FromArgb(105, 75, 54);
        Panel card = new()
        {
            Location = new Point(0, y),
            Size = new Size(627, 91),
            BackColor = Color.FromArgb(251, 247, 237)
        };

        string? imageName = product.Id switch
        {
            "BR001" => "sourdough.png",
            "BR002" => "brioche.png",
            "BR003" => "whole-wheat.png",
            "CO001" => "cookies.png",
            "CO002" => "oatmeal-cookie.png",
            "CO003" => "sugar-cookie.png",
            "MU001" => "blueberry-muffin.png",
            "MU002" => "lemon-poppy-muffin.png",
            "PA001" => "cinnamon.png",
            "PA002" => "croissant.png",
            "PI001" => "apple.png",
            "PI002" => "cherry-pie.png",
            "CA001" => "decorated-cake.png",
            "CA002" => "vanilla-cake.png",
            "EX001" => "honey-butter.png",
            "SEASON-0" => "cider-donut.png",
            "SEASON-1" => "pumpkin-bread.png",
            "SEASON-2" => "pecan-pie.png",
            "SEASON-3" => "sweet-potato-pie.png",
            "SEASON-4" => "gingerbread.png",
            "SEASON-5" => "cranberry-scone.png",
            "SEASON-6" => "peppermint-brownie.png",
            "SEASON-7" => "king-cake.png",
            "SEASON-8" => "sticky-bun.png",
            "SEASON-9" => "shortbread.png",
            _ => null
        };
        bool imageAdded = false;
        if (imageName is not null)
        {
            string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", imageName);
            if (File.Exists(imagePath))
            {
                try
                {
                    // Copy the image to avoid locking the file.
                    using Image source = Image.FromFile(imagePath);
                    Bitmap bitmap = new(source);
                    PictureBox picture = new()
                    {
                        Name = "itemImage",
                        Location = new Point(8, 7),
                        Size = new Size(78, 76),
                        BackColor = Color.FromArgb(255, 253, 249),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = bitmap
                    };
                    picture.Disposed += (_, _) => bitmap.Dispose();
                    card.Controls.Add(picture);
                    imageAdded = true;
                }
                catch (Exception) { }
            }
        }
        if (!imageAdded)
        {
            Label tile = new()
            {
                Name = "itemImage",
                Location = new Point(8, 7),
                Size = new Size(78, 76),
                BackColor = Color.FromArgb(232, 238, 219),
                ForeColor = olive,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Text = product.IsSeasonal ? "SEASON" : product.CategoryId.ToUpperInvariant() switch
                {
                    "BREADS" => "BREAD", "COOKIES" => "COOKIE", "MUFFINS" => "MUFFIN",
                    "PASTRIES" => "PASTRY", "PIES" => "PIE", "CAKES" => "CAKE",
                    "EXTRAS" => "EXTRA", _ => "BAKERY"
                },
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(tile);
        }

        card.Controls.Add(new Label
        {
            Name = "itemName",
            Location = new Point(101, 11),
            Size = new Size(321, 30),
            Text = product.Name,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 10.7f, FontStyle.Bold),
            ForeColor = olive,
            TextAlign = ContentAlignment.MiddleLeft
        });
        string description = product.IsSeasonal
            ? $"Seasonal: {product.SeasonStartMonth:00}/{product.SeasonStartDay:00} – {product.SeasonEndMonth:00}/{product.SeasonEndDay:00}"
            : product.Description;
        card.Controls.Add(new Label
        {
            Name = "itemDescription",
            Location = new Point(101, 43),
            Size = new Size(353, 28),
            Text = description,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 9.2f),
            ForeColor = brown,
            TextAlign = ContentAlignment.MiddleLeft
        });
        card.Controls.Add(new Label
        {
            Name = "itemPrice",
            Location = new Point(438, 10),
            Size = new Size(86, 27),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Text = DisplayFormat.Usd(product.Price),
            Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
            ForeColor = brown,
            TextAlign = ContentAlignment.MiddleRight
        });
        Button add = new()
        {
            Name = "itemAdd",
            Location = new Point(531, 22),
            Size = new Size(86, 48),
            Text = "ADD +",
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            BackColor = Color.FromArgb(223, 180, 81),
            ForeColor = olive,
            Font = new Font("Segoe UI", 10f, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat,
            UseVisualStyleBackColor = false,
            Cursor = Cursors.Hand,
            TabStop = true
        };
        add.FlatAppearance.BorderSize = 0;
        add.Click += (_, _) =>
        {
            try { AppData.Cart.Add(product); }
            catch (Exception ex) when (ex is InvalidOperationException or ArgumentOutOfRangeException)
            {
                EnglishDialog.Show(this, ex.Message, "Shopping cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };
        card.Controls.Add(add);
        return card;
    }

    private void ConfigureMenuDate()
    {
        filterLabel.Text = "BROWSE OUR MENU";
        filterLabel.Width = 274;
        categoryFilter.SetBounds(278, 17, 227, 30);

        Label dateLabel = new()
        {
            Name = "menuDateLabel",
            Text = "MENU DATE",
            Location = new Point(525, 15),
            Size = new Size(92, 36),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9.2f, FontStyle.Bold),
            ForeColor = Color.FromArgb(55, 73, 44)
        };
        _menuDate = new DateTimePicker
        {
            Name = "menuDatePicker",
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "MM/dd/yyyy",
            MinDate = DateTime.Today.AddYears(-1),
            MaxDate = DateTime.Today.AddYears(2),
            Value = AppData.Cart.MenuDate,
            Location = new Point(619, 17),
            Size = new Size(160, 29),
            Font = new Font("Segoe UI", 9.4f)
        };
        menuBadge.SetBounds(793, 13, 220, 38);
        filterCard.Controls.Add(dateLabel);
        filterCard.Controls.Add(_menuDate);
        _menuDate.ValueChanged += (_, _) =>
        {
            int removed = AppData.Cart.SelectMenuDate(_menuDate.Value.Date);
            RenderFilteredProducts();
            if (removed > 0)
                EnglishDialog.Show(this,
                    $"{removed} seasonal item(s) were removed from the cart because they are not sold on the selected menu date.",
                    "Seasonal availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
    }

    private void ConfigureCart()
    {
        basketEmpty.Visible = false;
        pickupLabel.Visible = false;
        pickupCombo.Visible = false;
        basketFootnote.Visible = false;
        basketTag.Text = "CART";

        _cartList = new Panel
        {
            Name = "cartLines",
            BackColor = Color.FromArgb(251, 236, 200),
            AutoScroll = true,
            TabIndex = 7
        };
        _cartSubtotal = new Label
        {
            Name = "cartSubtotal",
            ForeColor = Color.FromArgb(55, 73, 44),
            Font = new Font("Segoe UI", 12f, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleRight
        };
        _clearCart = new Button
        {
            Name = "clearCartButton",
            Text = "CLEAR",
            Font = new Font("Segoe UI", 8.8f, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(255, 253, 249),
            ForeColor = Color.FromArgb(55, 73, 44),
            Cursor = Cursors.Hand
        };
        _clearCart.FlatAppearance.BorderSize = 0;
        _clearCart.Click += (_, _) => AppData.Cart.Clear();
        basketCard.Controls.Add(_cartList);
        basketCard.Controls.Add(_cartSubtotal);
        basketCard.Controls.Add(_clearCart);
        basketCard.SizeChanged += (_, _) => UpdateBasketLayout();
        AppData.Cart.Changed += Cart_Changed;
        Disposed += (_, _) => AppData.Cart.Changed -= Cart_Changed;
        UpdateBasketLayout();
    }

    private void Cart_Changed(object? sender, EventArgs e)
    {
        if (IsDisposed || Disposing) return;
        // Rebuild after the click returns, so the clicked button is not disposed in its handler.
        if (IsHandleCreated) BeginInvoke(new Action(RenderCart));
        else RenderCart();
    }

    internal void UpdateBasketLayout()
    {
        if (_fittingBasket || _cartList is null || _cartSubtotal is null || _clearCart is null)
            return;
        _fittingBasket = true;
        try
        {
            int width = basketCard.ClientSize.Width;
            int height = basketCard.ClientSize.Height;
            int margin = Math.Max(16, (int)Math.Round(width * 23f / 350f));
            int available = Math.Max(160, width - margin * 2);
            basketTitle.SetBounds(margin, 14, available, 42);
            basketTag.SetBounds(margin, 59, available - 93, 30);
            _clearCart.SetBounds(width - margin - 78, 62, 78, 28);
            backAccount.SetBounds(margin, height - 51, available, 40);
            summaryButton.SetBounds(margin, height - 109, available, 51);
            _cartSubtotal.SetBounds(margin, height - 147, available, 31);
            _cartList.SetBounds(margin, 96, available, Math.Max(70, height - 247));
            FitCartRows();
        }
        finally { _fittingBasket = false; }
    }

    private void RenderCart()
    {
        if (_cartList is null || _cartSubtotal is null || _clearCart is null || IsDisposed) return;
        _cartList.SuspendLayout();
        foreach (Control existing in _cartList.Controls.Cast<Control>().ToArray())
        {
            _cartList.Controls.Remove(existing);
            existing.Dispose();
        }
        _cartList.AutoScrollPosition = Point.Empty;
        basketTag.Text = $"CART | {AppData.Cart.ItemCount} ITEMS";
        _clearCart.Enabled = AppData.Cart.ItemCount > 0;
        _cartSubtotal.Text = "Subtotal: " + DisplayFormat.Usd(AppData.Cart.Subtotal);

        if (AppData.Cart.Items.Count == 0)
        {
            Label empty = new()
            {
                Text = "Your basket is empty.\nChoose a product to get started.",
                Name = "emptyCartMessage",
                ForeColor = Color.FromArgb(105, 75, 54),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10f),
                Location = new Point(5, 18),
                Size = new Size(Math.Max(150, _cartList.ClientSize.Width - 15), 70)
            };
            _cartList.Controls.Add(empty);
            _cartList.AutoScrollMinSize = Size.Empty;
        }
        else
        {
            foreach (CartItem line in AppData.Cart.Items)
                _cartList.Controls.Add(CreateCartRow(line));
        }
        _cartList.ResumeLayout(true);
        UpdateBasketLayout();
    }

    private Panel CreateCartRow(CartItem line)
    {
        Color olive = Color.FromArgb(55, 73, 44);
        Color brown = Color.FromArgb(105, 75, 54);
        Panel row = new()
        {
            Name = "cartItemRow",
            Height = 72,
            BackColor = Color.FromArgb(255, 250, 237)
        };
        row.Controls.Add(new Label
        {
            Name = "cartLineName",
            Text = line.ProductName,
            ForeColor = olive,
            Font = new Font("Segoe UI", 9.1f, FontStyle.Bold),
            AutoEllipsis = true,
            TextAlign = ContentAlignment.MiddleLeft
        });
        row.Controls.Add(new Label
        {
            Name = "cartLineTotal",
            Text = DisplayFormat.Usd(line.LineTotal),
            ForeColor = brown,
            Font = new Font("Segoe UI", 9.4f, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleRight
        });
        row.Controls.Add(new Label
        {
            Name = "cartLineQty", Text = $"Qty: {line.Quantity}",
            ForeColor = brown, Font = new Font("Segoe UI", 9f),
            TextAlign = ContentAlignment.MiddleLeft
        });
        Button minus = CartButton("cartMinus", "-", 34);
        minus.Click += (_, _) =>
        {
            if (line.Quantity == 1) AppData.Cart.Remove(line.ProductId);
            else AppData.Cart.SetQuantity(line.ProductId, line.Quantity - 1);
        };
        Button plus = CartButton("cartPlus", "+", 34);
        plus.Click += (_, _) =>
        {
            try { AppData.Cart.SetQuantity(line.ProductId, line.Quantity + 1); }
            catch (ArgumentOutOfRangeException ex)
            {
                EnglishDialog.Show(this, ex.Message, "Shopping cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };
        Button remove = CartButton("cartRemove", "REMOVE", 66);
        remove.Click += (_, _) => AppData.Cart.Remove(line.ProductId);
        row.Controls.Add(minus);
        row.Controls.Add(plus);
        row.Controls.Add(remove);
        return row;
    }

    private static Button CartButton(string name, string label, int width)
    {
        Button button = new()
        {
            Name = name, Text = label, Size = new Size(width, 28),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(232, 238, 219),
            ForeColor = Color.FromArgb(55, 73, 44),
            Font = new Font("Segoe UI", 8f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderSize = 0;
        return button;
    }

    private void FitCartRows()
    {
        if (_cartList is null) return;
        int rowWidth = Math.Max(150, _cartList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 3);
        int index = 0;
        foreach (Control row in _cartList.Controls)
        {
            if (row is not Panel)
            {
                row.Width = Math.Max(120, rowWidth - 15);
                continue;
            }
            row.SetBounds(0, index++ * 77, rowWidth, 72);
            int right = rowWidth - 8;
            foreach (Control child in row.Controls)
            {
                switch (child.Name)
                {
                    case "cartLineName": child.SetBounds(9, 4, Math.Max(55, rowWidth - 116), 26); break;
                    case "cartLineTotal": child.SetBounds(rowWidth - 109, 4, 101, 26); break;
                    case "cartLineQty": child.SetBounds(9, 39, Math.Max(55, rowWidth - 155), 27); break;
                    case "cartMinus": child.SetBounds(right - 144, 37, 30, 28); break;
                    case "cartPlus": child.SetBounds(right - 109, 37, 30, 28); break;
                    case "cartRemove": child.SetBounds(right - 75, 37, 75, 28); break;
                }
            }
        }
        _cartList.AutoScrollMinSize = new Size(0, index * 77);
    }

    private void Navigate_Click(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Tag is string target &&
            Enum.TryParse<Page>(target, out Page page))
        {
            BakeryApplicationContext.Navigate(page);
        }
    }

    private void PreviewOnly_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            "The cart is available. Checkout and payment will be added in the next checkpoint.",
            "Olive Branch Bakes — Menu",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ProjectInfo_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            "Project: Olive Branch Bakes\nStudent: EnYan Chen\nCourse: CS3388 Object-Oriented Programming\n" +
            "Current features: category browsing, an editable shopping cart, and JSON data storage.\n" +
            "Checkout and order placement are planned for Phase 3C.",
            "About the project", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void LoadPreviewImages()
    {
        PictureBox[] pictures = { picture0, picture1, picture2, picture3 };
        string[] names = { "sourdough.png", "cinnamon.png", "cookies.png", "apple.png" };
        for (int i = 0; i < pictures.Length; i++)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Assets", names[i]);
                if (File.Exists(path)) pictures[i].Image = Image.FromFile(path);
            }
            catch (Exception) { }
        }
    }
}
