using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Navigation;
using OliveBranchBakes.Services;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace OliveBranchBakes.Forms;

public partial class OrderSummaryForm : Form
{
    private readonly ListView _cartSummary = new();
    private readonly DateTimePicker _pickup = new();
    private readonly TextBox _contactName = new();
    private readonly TextBox _contactPhone = new();
    private readonly TextBox _notes = new();
    private readonly Label _availability = new();

    private SchedulingService _scheduling = null!;
    private OrderService _orderService = null!;
    private BakeryOrder? _confirmedOrder;
    private bool _placingOrder;

    public OrderSummaryForm()
    {
        InitializeComponent();

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            return;

        _scheduling = new PickupService(AppData.Store.Settings);

        _orderService = new OrderService(
            AppData.Store,
            new PlanAheadPricingService(AppData.Store.Settings),
            _scheduling,
            AppData.Accounts);

        ConfigureCheckout();
        ShowCartSummary();

        _pickup.ValueChanged += (_, _) => RefreshQuote();

        RefreshQuote();
    }

    private void ConfigureCheckout()
    {
        pageTitle.Text = "Review and place your order";
        pageSubtitle.Text =
            "Choose your pickup time, check the total, and confirm your order.";
        pageSubtitle.Font = new Font("Segoe UI", 14f);

        footerRight.Text = "Pickup pre-orders | USD";

        summaryCard.SetBounds(40, 121, 689, 485);
        summaryCard.TabIndex = 1;

        summaryHeading.Text = "Your shopping cart";
        summaryHeading.Font = new Font(
            "Segoe UI", 17f, FontStyle.Bold);

        emptyBox.SetBounds(24, 78, 638, 170);

        emptyTitle.Text = "Nothing in the basket yet";
        emptyDetail.Text = "Return to ORDER and add an item.";
        emptyDetail.Font = new Font("Segoe UI", 14f);

        plannedTotals.SetBounds(26, 264, 630, 148);
        plannedTotals.Font = new Font("Segoe UI", 14f);

        nextCard.SetBounds(751, 121, 347, 485);
        nextCard.TabIndex = 0;

        nextTitle.Text = "Pickup and contact";
        nextTitle.Font = new Font(
            "Segoe UI", 17f, FontStyle.Bold);

        nextDescription.Visible = false;

        _pickup.Name = "checkoutPickup";
        _pickup.Format = DateTimePickerFormat.Custom;
        _pickup.CustomFormat = "MM/dd/yyyy HH:mm";

        DateTime now = DateTime.Now;
        DateTime initialPickup =
            AppData.Cart.MenuDate.Date.AddHours(10);

        if (initialPickup <
                now.AddHours(AppData.Store.Settings.MinimumAdvanceHours) ||
            initialPickup >
                now.AddDays(AppData.Store.Settings.MaximumAdvanceDays))
        {
            initialPickup = now.Date.AddDays(3).AddHours(10);
        }

        _pickup.Value = initialPickup;
        AddInput("PICKUP DATE / TIME (24H)", _pickup, 66, 0);

        _contactName.Name = "checkoutName";
        _contactName.PlaceholderText = "Full name";
        _contactName.MaxLength = 100;
        AddInput("FULL NAME", _contactName, 142, 1);

        _contactPhone.Name = "checkoutPhone";
        _contactPhone.PlaceholderText = "Phone number";
        _contactPhone.MaxLength = 30;
        AddInput("PHONE NUMBER", _contactPhone, 218, 2);

        _notes.Name = "checkoutNotes";
        _notes.PlaceholderText = "Optional order notes";
        _notes.Multiline = true;
        _notes.ScrollBars = ScrollBars.Vertical;
        _notes.MaxLength = 500;

        AddInput("ORDER NOTES (OPTIONAL)", _notes, 294, 3);
        _notes.Height = 52;

        _availability.Name = "pieAvailability";
        _availability.SetBounds(23, 389, 300, 75);
        _availability.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);
        _availability.ForeColor = Color.FromArgb(55, 73, 44);

        nextCard.Controls.Add(_availability);

        summaryCard.Controls.Add(backMenu);
        backMenu.SetBounds(26, 429, 300, 42);
        backMenu.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);
        backMenu.TabIndex = 1;

        summaryCard.Controls.Add(summaryAccount);
        summaryAccount.SetBounds(342, 429, 300, 42);
        summaryAccount.Text = "ACCOUNT / HISTORY";
        summaryAccount.Tag = "CustomerAccount";
        summaryAccount.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);
        summaryAccount.TabIndex = 2;

        placePreview.SetBounds(40, 624, 302, 54);
        placePreview.Text = "PLACE ORDER";
        placePreview.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);
        placePreview.TabIndex = 2;

        placeDisclaimer.SetBounds(361, 618, 730, 82);
        placeDisclaimer.Font = new Font("Segoe UI", 14f);

        Customer? customer = AppData.Accounts.CurrentCustomer;

        if (customer is not null)
        {
            _contactName.Text = customer.FullName;
            _contactPhone.Text = customer.Phone;
        }
    }

    private void AddInput(
        string labelText,
        Control input,
        int top,
        int tabIndex)
    {
        var label = new Label
        {
            Name = input.Name + "Label",
            Text = labelText,
            Location = new Point(23, top),
            Size = new Size(300, 26),
            Font = new Font(
                "Segoe UI", 14f, FontStyle.Bold),
            ForeColor = Color.FromArgb(55, 73, 44)
        };

        input.SetBounds(23, top + 29, 300, 34);
        input.Font = new Font("Segoe UI", 14f);
        input.TabIndex = tabIndex;

        nextCard.Controls.Add(label);
        nextCard.Controls.Add(input);
    }

    private void ShowCartSummary()
    {
        _cartSummary.Name = "cartSummaryList";
        _cartSummary.Dock = DockStyle.Fill;
        _cartSummary.View = View.Details;
        _cartSummary.FullRowSelect = true;
        _cartSummary.MultiSelect = false;
        _cartSummary.GridLines = true;
        _cartSummary.HeaderStyle =
            ColumnHeaderStyle.Nonclickable;
        _cartSummary.BackColor =
            Color.FromArgb(255, 253, 249);
        _cartSummary.ForeColor =
            Color.FromArgb(55, 73, 44);
        _cartSummary.Font = new Font("Segoe UI", 14f);
        _cartSummary.TabIndex = 0;

        _cartSummary.Columns.Add("Product", 280);
        _cartSummary.Columns.Add("Qty", 60);
        _cartSummary.Columns.Add("Unit", 120);
        _cartSummary.Columns.Add("Line total", 150);

        foreach (CartItem line in AppData.Cart.Items)
        {
            AddSummaryLine(
                line.ProductName,
                line.Quantity,
                line.UnitPrice,
                line.LineTotal);
        }

        _cartSummary.Resize += (_, _) => SizeSummaryColumns();

        emptyBox.Controls.Add(_cartSummary);

        bool hasItems = AppData.Cart.Items.Count > 0;

        emptyTitle.Visible = !hasItems;
        emptyDetail.Visible = !hasItems;
        _cartSummary.Visible = hasItems;

        if (hasItems)
            _cartSummary.BringToFront();

        SizeSummaryColumns();
    }

    private void AddSummaryLine(
        string name,
        int quantity,
        decimal unitPrice,
        decimal lineTotal)
    {
        var row = new ListViewItem(name);

        row.SubItems.Add(
            quantity.ToString(CultureInfo.InvariantCulture));
        row.SubItems.Add(Money(unitPrice));
        row.SubItems.Add(Money(lineTotal));

        _cartSummary.Items.Add(row);
    }

    private void SizeSummaryColumns()
    {
        if (_cartSummary.Columns.Count != 4 ||
            _cartSummary.ClientSize.Width < 200)
        {
            return;
        }

        int width = _cartSummary.ClientSize.Width -
            SystemInformation.VerticalScrollBarWidth - 6;

        _cartSummary.Columns[1].Width = width / 10;
        _cartSummary.Columns[2].Width = width / 5;
        _cartSummary.Columns[3].Width = width / 4;

        _cartSummary.Columns[0].Width =
            width -
            _cartSummary.Columns[1].Width -
            _cartSummary.Columns[2].Width -
            _cartSummary.Columns[3].Width;
    }

    private void RefreshQuote()
    {
        if (_confirmedOrder is not null)
            return;

        try
        {
            int remaining = _scheduling.GetRemainingPies(
                AppData.Store.Orders,
                AppData.Store.Products,
                _pickup.Value);

            _availability.Text =
                $"{remaining} of {AppData.Store.Settings.DailyPieLimit} pies available\n" +
                $"on {_pickup.Value:MM/dd/yyyy}.";

            PricingResult price = _orderService.Preview(
                AppData.Cart,
                DateTime.Now,
                _pickup.Value);

            ShowTotals(
                price.Subtotal,
                price.Discount,
                price.Fees,
                price.Tax,
                price.Total);

            placePreview.Enabled = true;

            ShowMessage(
                "Select PLACE ORDER to save your order and confirmation.",
                false);
        }
        catch (Exception ex) when (
            ex is ArgumentException or
            InvalidOperationException or
            IOException)
        {
            placePreview.Enabled = false;

            plannedTotals.Text =
                $"Cart subtotal: {Money(AppData.Cart.Subtotal)}\n" +
                "Choose a valid pickup to calculate your final total.";

            ShowMessage(ex.Message, true);
        }
    }

    private void ShowTotals(
        decimal subtotal,
        decimal discount,
        decimal fees,
        decimal tax,
        decimal total)
    {
        plannedTotals.Text =
            $"Subtotal: {Money(subtotal)}\n" +
            $"Plan-ahead discount: -{Money(discount)}\n" +
            $"Rush fee: {Money(fees)}\n" +
            $"Tax ({AppData.Store.Settings.TaxRate:P1}): {Money(tax)}\n" +
            $"TOTAL: {Money(total)}";
    }

    private void PreviewOnly_Click(object? sender, EventArgs e)
    {
        if (_placingOrder || _confirmedOrder is not null)
            return;

        _placingOrder = true;
        placePreview.Enabled = false;

        try
        {
            BakeryOrder order = _orderService.PlaceOrder(
                AppData.Cart,
                _contactName.Text,
                _contactPhone.Text,
                _pickup.Value,
                _notes.Text);

            _confirmedOrder = order;

            pageTitle.Text = "Your order is confirmed";
            pageSubtitle.Text =
                $"Pickup: {DisplayFormat.PickupTime(order.PickupAt)} | Status: Received";
            summaryHeading.Text = order.ConfirmationNumber;

            _cartSummary.Items.Clear();

            foreach (OrderItem item in order.Items)
            {
                AddSummaryLine(
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice,
                    item.LineTotal);
            }

            ShowTotals(
                order.Subtotal,
                order.Discount,
                order.Fees,
                order.Tax,
                order.Total);

            _contactName.Text = order.ContactName;
            _contactPhone.Text = order.ContactPhone;
            _notes.Text = order.Notes;

            _pickup.Enabled = false;
            _contactName.ReadOnly = true;
            _contactPhone.ReadOnly = true;
            _notes.ReadOnly = true;

            placePreview.Text = "ORDER SAVED";
            placePreview.Enabled = false;

            _availability.Text =
                "Status: Received\nKeep your confirmation number.";

            footerRight.Text = "Order confirmed";

            ShowMessage(
                $"Saved: {order.ConfirmationNumber}. " +
                "Signed-in orders also appear in ACCOUNT / HISTORY.",
                false);

            body.ScrollControlIntoView(pageTitle);
        }
        catch (Exception ex) when (
            ex is ArgumentException or
            InvalidOperationException or
            IOException or
            UnauthorizedAccessException)
        {
            RefreshQuote();
            ShowMessage(ex.Message, true);
        }
        finally
        {
            _placingOrder = false;
        }
    }

    private void ShowMessage(string message, bool isError)
    {
        placeDisclaimer.Text = message;
        placeDisclaimer.ForeColor = isError
            ? Color.Firebrick
            : Color.FromArgb(55, 73, 44);

        if (isError && IsHandleCreated && Visible)
            body.ScrollControlIntoView(placeDisclaimer);
    }

    private static string Money(decimal amount) =>
        DisplayFormat.Usd(
            Math.Round(
                amount,
                2,
                MidpointRounding.AwayFromZero));

    private void Navigate_Click(object? sender, EventArgs e)
    {
        if (sender is Button button &&
            button.Tag is string target &&
            Enum.TryParse<Page>(target, out Page page))
        {
            BakeryApplicationContext.Navigate(page);
        }
    }

    private void ProjectInfo_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            this,
            "Olive Branch Bakes\n" +
            "Customer accounts, P5 pricing, O1 pie capacity and saved orders.",
            "About the project",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}