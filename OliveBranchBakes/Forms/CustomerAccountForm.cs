using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Navigation;
using System.ComponentModel;
using System.Drawing;

namespace OliveBranchBakes.Forms;

/// <summary>Displays customer accounts and order history.</summary>
public partial class CustomerAccountForm : Form
{
    private readonly TextBox _phone = new();
    private readonly TextBox _history = new();

    public CustomerAccountForm()
    {
        InitializeComponent();

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            return;

        ConfigureAccountPage();
        RefreshAccount();
    }

    private void ConfigureAccountPage()
    {
        pageTitle.Text = "Your account and orders";
        pageSubtitle.Text =
            "Sign in with email and password. Enter all four fields to create an account.";
        pageSubtitle.Font = new Font("Segoe UI", 14f);

        footerRight.Text = "Customer accounts and order history";

        accountCard.Height = 500;
        accountRight.Height = 500;
        accountHeader.AutoEllipsis = true;

        firstNameLabel.SetBounds(25, 68, 595, 28);

        fullName.SetBounds(25, 100, 595, 35);
        fullName.PlaceholderText = "Enter your full name";
        fullName.MaxLength = 100;
        fullName.TabIndex = 0;

        var phoneLabel = new Label
        {
            Name = "accountPhoneLabel",
            Text = "PHONE NUMBER",
            Location = new Point(25, 150),
            Size = new Size(595, 28),
            Font = firstNameLabel.Font,
            ForeColor = firstNameLabel.ForeColor,
            TextAlign = ContentAlignment.MiddleLeft
        };

        accountCard.Controls.Add(phoneLabel);

        _phone.Name = "accountPhone";
        _phone.SetBounds(25, 182, 595, 35);
        _phone.Font = fullName.Font;
        _phone.PlaceholderText = "Enter your phone number";
        _phone.MaxLength = 30;
        _phone.TabIndex = 1;

        accountCard.Controls.Add(_phone);

        emailLabel.SetBounds(25, 232, 595, 28);

        email.SetBounds(25, 264, 595, 35);
        email.PlaceholderText = "you@example.com";
        email.MaxLength = 254;
        email.TabIndex = 2;

        passwordLabel.SetBounds(25, 314, 595, 28);
        passwordLabel.Text =
            "PASSWORD (8+ CHARACTERS, INCLUDING A NUMBER)";

        password.SetBounds(25, 346, 595, 35);
        password.UseSystemPasswordChar = true;
        password.PlaceholderText = "Enter your password";
        password.TabIndex = 3;

        signIn.SetBounds(25, 418, 278, 55);
        signIn.TabIndex = 4;

        register.SetBounds(319, 418, 300, 55);
        register.Text = "CREATE ACCOUNT";
        register.TabIndex = 5;

        foreach (Control control in accountCard.Controls)
        {
            control.Font = new Font(
                "Segoe UI",
                Math.Max(14f, control.Font.SizeInPoints),
                control.Font.Style);
        }

        accountRightTitle.Text = "Your saved orders";
        accountRightText.Visible = false;

        _history.Name = "accountHistory";
        _history.SetBounds(22, 85, 337, 323);
        _history.Multiline = true;
        _history.ReadOnly = true;
        _history.WordWrap = true;
        _history.ScrollBars = ScrollBars.Vertical;
        _history.BorderStyle = BorderStyle.None;
        _history.BackColor = accountRight.BackColor;
        _history.ForeColor = accountRightText.ForeColor;
        _history.Font = new Font("Segoe UI", 14f);
        _history.TabIndex = 0;

        accountRight.Controls.Add(_history);

        accountSummary.SetBounds(21, 430, 337, 50);
        accountSummary.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);
        accountSummary.TabIndex = 1;

        accountBottom.SetBounds(40, 635, 1050, 65);
        accountBottom.Font = new Font("Segoe UI", 14f);
    }

    private void RefreshAccount()
    {
        Customer? customer = AppData.Accounts.CurrentCustomer;
        bool signedIn = customer is not null;

        signIn.Text = signedIn ? "SIGN OUT" : "SIGN IN";
        register.Enabled = !signedIn;

        fullName.ReadOnly = signedIn;
        _phone.ReadOnly = signedIn;
        email.ReadOnly = signedIn;
        password.Enabled = !signedIn;
        password.Clear();

        if (customer is not null)
        {
            fullName.Text = customer.FullName;
            _phone.Text = customer.Phone;
            email.Text = customer.Email;

            accountHeader.Text = "Signed in: " + customer.FullName;
        }
        else
        {
            accountHeader.Text = "Customer account";
        }

        var orders = AppData.Accounts.GetOrderHistory();

        if (!signedIn)
        {
            _history.Text = "Sign in to view your order history.";
        }
        else if (orders.Count == 0)
        {
            _history.Text =
                "No saved orders yet. Start an order from the menu.";
        }
        else
        {
            _history.Text = string.Join(
                Environment.NewLine + Environment.NewLine,
                orders.Select(FormatOrder));
        }

        accountBottom.ForeColor = Color.FromArgb(55, 73, 44);
        accountBottom.Text = signedIn
            ? "Your name and phone are available for checkout."
            : "Name and phone are required when creating an account.";
    }

    private static string FormatOrder(BakeryOrder order)
    {
        string newline = Environment.NewLine;

        string status = order.Status == OrderStatus.PickedUp
            ? "Picked Up"
            : order.Status.ToString();

        string items = string.Join(
            ", ",
            order.Items.Select(item =>
                $"{item.Quantity} x {item.ProductName}"));

        return
            $"{order.ConfirmationNumber}{newline}" +
            $"Pickup: {DisplayFormat.PickupTime(order.PickupAt)}{newline}" +
            $"Status: {status}{newline}" +
            $"{items}{newline}" +
            $"Total: {DisplayFormat.Usd(order.Total)}";
    }

    private void PreviewOnly_Click(object? sender, EventArgs e)
    {
        try
        {
            string message;

            if (sender == register)
            {
                AppData.Accounts.CreateAccount(
                    fullName.Text,
                    email.Text,
                    _phone.Text,
                    password.Text);

                message = "Account created. You are now signed in.";
            }
            else if (sender == signIn)
            {
                if (AppData.Accounts.CurrentCustomer is null)
                {
                    AppData.Accounts.SignIn(
                        email.Text,
                        password.Text);

                    message = "You are now signed in.";
                }
                else
                {
                    AppData.Accounts.SignOut();

                    fullName.Clear();
                    _phone.Clear();
                    email.Clear();

                    message = "You have signed out.";
                }
            }
            else
            {
                return;
            }

            RefreshAccount();
            ShowStatus(message, false);
        }
        catch (Exception ex) when (
            ex is ArgumentException or
            InvalidOperationException or
            IOException or
            UnauthorizedAccessException)
        {
            password.Clear();
            ShowStatus(ex.Message, true);
        }
    }

    private void ShowStatus(string message, bool isError)
    {
        accountBottom.Text = message;
        accountBottom.ForeColor = isError
            ? Color.Firebrick
            : Color.FromArgb(55, 73, 44);

        body.ScrollControlIntoView(accountBottom);
    }

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
            "Project: Olive Branch Bakes\n" +
            "Student: EnYan Chen\n" +
            "Course: CS3388 Object-Oriented Programming\n" +
            "Features: customer registration, sign-in and order history.",
            "About the project",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}