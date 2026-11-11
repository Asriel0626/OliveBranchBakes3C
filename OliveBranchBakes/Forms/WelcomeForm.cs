using OliveBranchBakes.Navigation;
using OliveBranchBakes.Data;
using System.ComponentModel;
using System.Drawing;

namespace OliveBranchBakes.Forms;

public partial class WelcomeForm : Form
{
    public WelcomeForm()
    {
        InitializeComponent();
        LoadPreviewImages();

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            return;

        var customer = AppData.Accounts.CurrentCustomer;

        startOrder.Text = customer is null
            ? "ORDER AS GUEST"
            : "START AN ORDER";

        accountNow.Text = customer is null
            ? "SIGN IN / REGISTER"
            : "MY ACCOUNT";

        startOrder.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);

        accountNow.Font = new Font(
            "Segoe UI", 14f, FontStyle.Bold);

        pageSubtitle.Text = customer is null
            ? "Order as a guest, or sign in to view your order history."
            : $"Welcome back, {customer.FullName}.";

        pageSubtitle.Width = 670;
        pageSubtitle.AutoEllipsis = true;
        pageSubtitle.Font = new Font("Segoe UI", 14f);

        heroDesc.Text =
            "Browse our menu, choose pickup, and place your order.";

        featureTitle0.Text = "Browse baked goods";
        featureDescription0.Text =
            "Handmade breads, pastries, cookies.";

        featureTitle1.Text = "Plan your pickup";
        featureDescription1.Text =
            "Choose pickup and view totals.";

        featureTitle2.Text = "Your account";
        featureDescription2.Text =
            "Sign in to view saved orders.";

        featureDescription0.Font = new Font("Segoe UI", 14f);
        featureDescription1.Font = new Font("Segoe UI", 14f);
        featureDescription2.Font = new Font("Segoe UI", 14f);

        var savedDataButton = new Button
        {
            Name = "viewSavedDataButton",
            Text = "VIEW SAVED DATA",
            Location = new Point(742, 26),
            Size = new Size(340, 52),
            BackColor = Color.FromArgb(79, 98, 62),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI", 14f, FontStyle.Bold),
            TabIndex = 4
        };

        savedDataButton.FlatAppearance.BorderSize = 0;

        savedDataButton.Click += (_, _) =>
            BakeryApplicationContext.Navigate(Page.SavedData);

        body.Controls.Add(savedDataButton);
        savedDataButton.BringToFront();

        phaseNotice.Location = new Point(310, 596);
        phaseNotice.Size = new Size(790, 42);
        phaseNotice.Font = new Font("Segoe UI", 14f);
        phaseNotice.Text =
            "Administrator controls: Coming in Phase 4.";

        footerLeft.Text =
            "OLIVE BRANCH BAKES  •  PRE-ORDER SYSTEM";
        footerRight.Text =
            "Accounts, checkout and order saving available";
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

    private void PreviewOnly_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            this,
            "Administrator controls are coming in Phase 4.",
            "Coming in Phase 4",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ProjectInfo_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            this,
            "Project: Olive Branch Bakes\n" +
            "Student: EnYan Chen\n" +
            "Course: CS3388 Object-Oriented Programming\n" +
            "Phase 3C: Customer Ordering System\n\n" +
            "Features: menu browsing, shopping cart, customer accounts, " +
            "P5 pricing, O1 pie capacity, saved orders and confirmations.\n\n" +
            "Administrator controls: Coming in Phase 4.",
            "About the project",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void LoadPreviewImages()
    {
        try
        {
            string path = Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "bakery-hero.png");

            if (!File.Exists(path))
                return;

            using Image source = Image.FromFile(path);
            var image = new Bitmap(source);

            heroPicture.Image = image;
            heroPicture.Disposed += (_, _) => image.Dispose();
        }
        catch (Exception)
        {
            // The page remains available if its image cannot be loaded.
        }
    }
}