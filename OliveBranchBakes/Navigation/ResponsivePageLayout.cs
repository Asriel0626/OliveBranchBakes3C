using OliveBranchBakes.Forms;
using System.Drawing;

namespace OliveBranchBakes.Navigation;

internal sealed class ResponsivePageLayout
{
    private readonly Form _page;
    private readonly Control _header;
    private readonly Control _footer;
    private readonly ScrollableControl _body;
    private readonly Dictionary<Control, Original> _items = new();
    private bool _updating;

    private sealed record Original(Rectangle Bounds, Font Font);

    private ResponsivePageLayout(Form page, Control header, Control footer, ScrollableControl body)
    {
        _page = page;
        _header = header;
        _footer = footer;
        _body = body;
        SaveLayout(header);
        SaveLayout(footer);
        SaveLayout(body);
        _body.AutoScrollMinSize = Size.Empty;
        _page.SizeChanged += (_, _) => Apply();
        _page.Shown += (_, _) => Apply();
        Apply();
    }

    internal static void Attach(Form page)
    {
        Control? header = page.Controls.Find("header", false).FirstOrDefault();
        Control? footer = page.Controls.Find("footer", false).FirstOrDefault();
        Control? body = page.Controls.Find("body", false).FirstOrDefault();
        if (header is null || footer is null || body is not ScrollableControl scroll)
            return; // An unrecognized page can still be displayed normally.
        _ = new ResponsivePageLayout(page, header, footer, scroll);
    }

    private void SaveLayout(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            if (child.Name is "jsonMenuList" or "cartLines") continue;
            _items[child] = new Original(child.Bounds, child.Font);
            if (child.Dock == DockStyle.None)
                child.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            SaveLayout(child);
        }
    }

    private void Apply()
    {
        if (_updating || _page.IsDisposed || _page.ClientSize.Width < 300 || _page.ClientSize.Height < 250)
            return;
        _updating = true;
        try
        {
            float sx = _page.ClientSize.Width / 1140f;
            float sy = _page.ClientSize.Height / 760f;
            int headerHeight = Math.Clamp((int)Math.Round(103 * Math.Sqrt(sy)), 88, 160);
            int footerHeight = Math.Clamp((int)Math.Round(36 * Math.Sqrt(sy)), 31, 55);
            _page.SuspendLayout();
            _header.Height = headerHeight;
            _footer.Height = footerHeight;
            _page.ResumeLayout(true);
            float bodyScale = Math.Max(.75f, _body.ClientSize.Height / 690f);
            float fontScale = Math.Clamp(Math.Min(sx, Math.Max(bodyScale, .9f)), .88f, 1.7f);

            _header.SuspendLayout();
            _body.SuspendLayout();
            _footer.SuspendLayout();
            ResizeChildren(_header, sx, headerHeight / 103f, fontScale);
            ResizeChildren(_footer, sx, footerHeight / 36f, fontScale);
            ResizeChildren(_body, sx, bodyScale, fontScale);
            _body.AutoScrollMinSize = new Size(0, (int)Math.Round(705 * bodyScale));
            _header.ResumeLayout(true);
            _body.ResumeLayout(true);
            _footer.ResumeLayout(true);
            if (_page is CustomerOrderForm menu)
            {
                menu.UpdateMenuLayout();
                menu.UpdateBasketLayout();
            }
        }
        finally
        {
            _updating = false;
        }
    }

    private void ResizeChildren(Control parent, float sx, float sy, float fontScale)
    {
        foreach (Control child in parent.Controls)
        {
            if (!_items.TryGetValue(child, out Original? original)) continue;
            if (child.Dock == DockStyle.None)
            {
                var r = original.Bounds;
                child.Bounds = new Rectangle(
                    (int)Math.Round(r.X * sx), (int)Math.Round(r.Y * sy),
                    Math.Max(1, (int)Math.Round(r.Width * sx)),
                    Math.Max(1, (int)Math.Round(r.Height * sy)));
            }
            if (child is not Panel && child is not PictureBox && child is not ComboBox)
            {
                float size = Math.Max(8f, original.Font.SizeInPoints * fontScale);
                if (Math.Abs(child.Font.SizeInPoints - size) > .18f)
                    child.Font = new Font(original.Font.FontFamily, size, original.Font.Style, GraphicsUnit.Point);
            }
            if (child.Name != "jsonMenuList")
                ResizeChildren(child, sx, sy, fontScale);
        }
    }
}
