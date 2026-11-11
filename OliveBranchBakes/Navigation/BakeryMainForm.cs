using OliveBranchBakes.Forms;
using System.Drawing;

namespace OliveBranchBakes.Navigation;

internal sealed class BakeryMainForm : Form
{
    private const string ApplicationTitle =
        "Olive Branch Bakes | Phase 3C";

    private Form? _activePage;

    internal static BakeryMainForm? Current { get; private set; }

    public BakeryMainForm()
    {
        Current = this;

        Text = ApplicationTitle;
        ClientSize = new Size(1140, 760);
        MinimumSize = new Size(970, 680);
        StartPosition = FormStartPosition.CenterScreen;
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(251, 247, 237);

        ShowPage(Page.Welcome);
    }

    internal void ShowPage(Page destination)
    {
        if (destination is Page.AdministratorLogin
            or Page.AdministratorConsole)
        {
            EnglishDialog.Show(
                this,
                "Administrator controls are coming in Phase 4.",
                "Coming in Phase 4",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        Form next = destination switch
        {
            Page.Welcome => new WelcomeForm(),
            Page.CustomerOrder => new CustomerOrderForm(),
            Page.CustomerAccount => new CustomerAccountForm(),
            Page.OrderSummary => new OrderSummaryForm(),
            Page.SavedData => new SavedDataForm(),
            _ => throw new ArgumentOutOfRangeException(
                nameof(destination))
        };

        next.TopLevel = false;
        next.FormBorderStyle = FormBorderStyle.None;
        next.ShowInTaskbar = false;
        next.StartPosition = FormStartPosition.Manual;
        next.MinimumSize = Size.Empty;
        next.MaximumSize = Size.Empty;
        next.AutoScaleMode = AutoScaleMode.None;
        next.Dock = DockStyle.Fill;

        if (destination != Page.SavedData)
            ResponsivePageLayout.Attach(next);

        Form? old = _activePage;

        SuspendLayout();

        if (old is not null)
        {
            old.Hide();
            Controls.Remove(old);
        }

        _activePage = next;

        Controls.Add(next);
        next.Show();
        next.BringToFront();

        Text = ApplicationTitle + " - " + destination;

        ResumeLayout(true);

        if (old is not null)
        {
            if (IsHandleCreated)
                BeginInvoke(new Action(old.Dispose));
            else
                old.Dispose();
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Current = null;
        base.OnFormClosed(e);
    }
}