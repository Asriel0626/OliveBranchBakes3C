using System.Drawing;

namespace OliveBranchBakes.Forms;

internal static class EnglishDialog
{
    public static DialogResult Show(string message, string title,
        MessageBoxButtons buttons, MessageBoxIcon icon) => Display(null, message, title);

    public static DialogResult Show(IWin32Window owner, string message, string title,
        MessageBoxButtons buttons, MessageBoxIcon icon) => Display(owner, message, title);

    private static DialogResult Display(IWin32Window? owner, string message, string title)
    {
        using Form dialog = new()
        {
            Text = title,
            ClientSize = new Size(570, 225),
            MinimumSize = new Size(480, 220),
            StartPosition = owner is null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ShowInTaskbar = false,
            BackColor = Color.FromArgb(251, 247, 237),
            Font = new Font("Segoe UI", 10f)
        };
        Label content = new()
        {
            Text = message,
            Dock = DockStyle.Fill,
            ForeColor = Color.FromArgb(55, 73, 44),
            Padding = new Padding(25, 18, 25, 10),
            TextAlign = ContentAlignment.MiddleLeft
        };
        Panel footer = new() { Dock = DockStyle.Bottom, Height = 67 };
        Button ok = new()
        {
            Text = "OK",
            DialogResult = DialogResult.OK,
            Size = new Size(112, 39),
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            Location = new Point(432, 10),
            BackColor = Color.FromArgb(79, 98, 62),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        ok.FlatAppearance.BorderSize = 0;
        footer.Controls.Add(ok);
        dialog.Controls.Add(content);
        dialog.Controls.Add(footer);
        dialog.AcceptButton = ok;
        dialog.CancelButton = ok;
        IWin32Window? parent = OliveBranchBakes.Navigation.BakeryMainForm.Current is { IsDisposed: false } main
            ? main : owner;
        return parent is null ? dialog.ShowDialog() : dialog.ShowDialog(parent);
    }
}
