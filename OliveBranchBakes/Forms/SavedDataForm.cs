using OliveBranchBakes.Navigation;
using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace OliveBranchBakes.Forms;

/// <summary>Displays saved products, customers, and sample orders.</summary>
public sealed class SavedDataForm : Form
{
    private static readonly Color Olive = Color.FromArgb(79, 98, 62);
    private static readonly Color Cream = Color.FromArgb(251, 247, 237);
    
    private readonly DataStore _store = AppData.Store;
    private readonly Label _summary = new();
    private readonly Label _variant = new();
    private readonly Label _status = new();
    private readonly TextBox _digits = new();
    private readonly DataGridView _products = CreateGrid();
    private readonly DataGridView _customers = CreateGrid();
    private readonly DataGridView _orders = CreateGrid();
    private readonly TabControl _tabs = new();

    public SavedDataForm()
    {
        Text = "Olive Branch Bakes | Saved Data";
        StartPosition = FormStartPosition.Manual;
        Size = new Size(1110, 790);
        MinimumSize = new Size(930, 690);
        Font = new Font("Segoe UI", 10f);
        BackColor = Cream;

        Panel titlePanel = new() { Dock = DockStyle.Top, Height = 190, BackColor = Cream };
        var heading = NewLabel("SAVED BAKERY DATA - USD", 21, FontStyle.Bold, Olive,
            new Point(25, 10), new Size(730, 45));
        titlePanel.Controls.Add(heading);
        _summary.Location = new Point(28, 58);
        _summary.Size = new Size(1010, 28);
        _summary.Font = new Font("Segoe UI", 11, FontStyle.Regular);
        _summary.ForeColor = Color.FromArgb(105, 75, 54);
        titlePanel.Controls.Add(_summary);

        var add = ActionButton("SAVE SAMPLE ORDER", new Point(28, 98), 185, (_, _) => RunSafely(() =>
        {
            BakeryOrder created = _store.AddSampleOrder();
            UpdateGrids();
            _tabs.SelectedIndex = 2;
            if (_orders.Rows.Count > 0)
            {
                _orders.ClearSelection();
                _orders.Rows[0].Selected = true;
                _orders.CurrentCell = _orders.Rows[0].Cells[0];
            }
            _status.Text = "Latest saved order: " + created.ConfirmationNumber + " - stored in orders.json.";
            EnglishDialog.Show(this, "Saved " + created.ConfirmationNumber + " to orders.json.\n\n" +
                "Close the application, reopen, and verify this record remains on the Orders tab.",
                "Persistent Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }));
        titlePanel.Controls.Add(add);
        titlePanel.Controls.Add(ActionButton("RELOAD JSON", new Point(224, 98), 160, (_, _) => RunSafely(() =>
        {
            _store.Reload();
            AppData.Cart.SyncWithMenu(_store.Products);
            UpdateGrids();
            _status.Text = "Reloaded menu, customers, orders and settings directly from disk.";
        })));
        titlePanel.Controls.Add(ActionButton("OPEN DATA FOLDER", new Point(395, 98), 200, (_, _) => RunSafely(() =>
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + _store.FolderPath + "\"")
            { UseShellExecute = true });
        })));
        _digits.Location = new Point(610, 102);
        _digits.Size = new Size(127, 31);
        _digits.MaxLength = 3;
        _digits.PlaceholderText = "Last 3 digits";
        _digits.Text = _store.Settings.IsDemoVariant ? "" : _store.Settings.VariantDigits;
        _digits.AccessibleDescription = "Only the last three digits of your student ID";
        titlePanel.Controls.Add(_digits);
        titlePanel.Controls.Add(ActionButton("SET VARIANT", new Point(750, 98), 150, (_, _) => RunSafely(() =>
        {
            _store.SelectVariant(_digits.Text.Trim());
            AppData.Cart.SyncWithMenu(_store.Products);
            UpdateGrids();
            _status.Text = "Saved variant selection to settings.json and seasonal menu item to products.json.";
        })));
        Button back = ActionButton("BACK TO HOME", new Point(918, 98), 165,
            (_, _) => BakeryApplicationContext.Navigate(Page.Welcome));
        back.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        titlePanel.Controls.Add(back);
        titlePanel.Resize += (_, _) =>
        {
            back.Left = Math.Max(760, titlePanel.ClientSize.Width - back.Width - 24);
        };
        _variant.Location = new Point(28, 150);
        _variant.Size = new Size(1025, 34);
        _variant.ForeColor = Olive;
        _variant.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        titlePanel.Controls.Add(_variant);

        var bottom = new Panel { Dock = DockStyle.Bottom, Height = 75, BackColor = Color.FromArgb(232, 238, 219) };
        _status.Location = new Point(18, 7);
        _status.Size = new Size(1030, 28);
        _status.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        _status.ForeColor = Olive;
        _status.Text = "Sample orders can be saved here. Customer checkout is not available yet.";
        var path = NewLabel("JSON folder: " + _store.FolderPath, 8.5f, FontStyle.Regular,
            Color.FromArgb(105, 75, 54), new Point(18, 36), new Size(1035, 28));
        bottom.Controls.Add(_status);
        bottom.Controls.Add(path);

        _tabs.Dock = DockStyle.Fill;
        _tabs.Font = new Font("Segoe UI", 10.5f);
        AddTab(_tabs, "Menu", _products);
        AddTab(_tabs, "Customers", _customers);
        AddTab(_tabs, "Orders", _orders);
        Controls.Add(_tabs);
        Controls.Add(bottom);
        Controls.Add(titlePanel);
        UpdateGrids();
    }

    private static Label NewLabel(string text, float size, FontStyle style, Color color, Point at, Size dimensions) =>
        new() { Text = text, Font = new Font("Segoe UI", size, style), ForeColor = color,
            Location = at, Size = dimensions, TextAlign = ContentAlignment.MiddleLeft };

    private static Button ActionButton(string text, Point point, int width, EventHandler action)
    {
        Button b = new() { Text = text, Location = point, Size = new Size(width, 43),
            FlatStyle = FlatStyle.Flat, BackColor = Olive, ForeColor = Color.White,
            Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9.1f, FontStyle.Bold) };
        b.FlatAppearance.BorderSize = 0;
        b.Click += action;
        return b;
    }

    private static DataGridView CreateGrid() => new()
    {
        Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
        AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false,
        RowHeadersVisible = false, AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
        DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Segoe UI", 10f),
            Padding = new Padding(5), WrapMode = DataGridViewTriState.True },
        ColumnHeadersHeight = 39
    };

    private static void AddTab(TabControl tabs, string title, DataGridView grid)
    {
        TabPage page = new(title) { BackColor = Color.White, Padding = new Padding(8) };
        page.Controls.Add(grid);
        tabs.TabPages.Add(page);
    }

    private void UpdateGrids()
    {
        _products.DataSource = _store.Products
            .OrderBy(x => x.CategoryId).ThenBy(x => x.Name)
            .Select(x => new { x.Id, x.Name, Category = x.CategoryId, Price = DisplayFormat.Usd(x.Price),
                Seasonal = x.IsSeasonal ? "YES" : "", AvailableToday = x.IsAvailableOn(DateTime.Today) ? "YES" : "NO",
                Season = x.IsSeasonal ? $"{x.SeasonStartMonth:00}/{x.SeasonStartDay:00} - {x.SeasonEndMonth:00}/{x.SeasonEndDay:00}" : "Year-round" })
            .ToList();
        _customers.DataSource = _store.Customers.Select(x => new
        {
            x.Id, x.FullName, x.Email, x.Phone,
            PasswordStorage = !string.IsNullOrEmpty(x.PasswordHash) && !string.IsNullOrEmpty(x.PasswordSalt)
                ? "Salt + PBKDF2 hash (no plaintext)" : "NOT SET"
        }).ToList();
        _orders.DataSource = _store.Orders.OrderByDescending(x => x.PlacedAt).Select(x => new
        {
            x.ConfirmationNumber, Customer = x.ContactName,
            Pickup = DisplayFormat.PickupTime(x.PickupAt),
            Items = string.Join(", ", x.Items.Select(y => $"{y.Quantity} x {y.ProductName}")),
            Subtotal = DisplayFormat.Usd(x.Subtotal), Total = DisplayFormat.Usd(x.Total),
            Status = x.Status.ToString()
        }).ToList();
        _summary.Text = $"{_store.Categories.Count} categories  |  {_store.Products.Count} menu items  |  {_store.Customers.Count} customers  |  {_store.Orders.Count} saved orders  |  USD / English";
        string setting = _store.Settings.IsDemoVariant ? "Default settings (update your variant)" : "Selected variant";
        _variant.Text = $"{setting}  |  {_store.Settings.SeasonalItemLabel}  |  {_store.Settings.OperationsLabel}  |  {_store.Settings.PricingLabel}";
    }

    private void RunSafely(Action action)
    {
        try { action(); }
        catch (Exception ex)
        {
            EnglishDialog.Show(this, ex.Message, "Data operation could not finish",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
