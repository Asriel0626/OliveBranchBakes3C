namespace OliveBranchBakes.Forms;

partial class AdministratorLoginForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.Panel header = null!;
    private System.Windows.Forms.Panel footer = null!;
    private System.Windows.Forms.Panel body = null!;
    private System.Windows.Forms.Label brand = null!;
    private System.Windows.Forms.Label tagline = null!;
    private System.Windows.Forms.Button nav0 = null!;
    private System.Windows.Forms.Button nav1 = null!;
    private System.Windows.Forms.Button nav2 = null!;
    private System.Windows.Forms.Button nav3 = null!;
    private System.Windows.Forms.Button nav4 = null!;
    private System.Windows.Forms.Label footerLeft = null!;
    private System.Windows.Forms.Label footerRight = null!;
    private System.Windows.Forms.Label pageTitle = null!;
    private System.Windows.Forms.Label pageSubtitle = null!;
    private System.Windows.Forms.Panel loginPanel = null!;
    private System.Windows.Forms.Label loginTitle = null!;
    private System.Windows.Forms.Label usernameLabel = null!;
    private System.Windows.Forms.TextBox username = null!;
    private System.Windows.Forms.Label adminPasswordLabel = null!;
    private System.Windows.Forms.TextBox adminPassword = null!;
    private System.Windows.Forms.Button previewConsole = null!;
    private System.Windows.Forms.Label securityNotice = null!;
    private System.Windows.Forms.Button loginHome = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.header = new System.Windows.Forms.Panel();
        this.footer = new System.Windows.Forms.Panel();
        this.body = new System.Windows.Forms.Panel();
        this.brand = new System.Windows.Forms.Label();
        this.tagline = new System.Windows.Forms.Label();
        this.nav0 = new System.Windows.Forms.Button();
        this.nav1 = new System.Windows.Forms.Button();
        this.nav2 = new System.Windows.Forms.Button();
        this.nav3 = new System.Windows.Forms.Button();
        this.nav4 = new System.Windows.Forms.Button();
        this.footerLeft = new System.Windows.Forms.Label();
        this.footerRight = new System.Windows.Forms.Label();
        this.pageTitle = new System.Windows.Forms.Label();
        this.pageSubtitle = new System.Windows.Forms.Label();
        this.loginPanel = new System.Windows.Forms.Panel();
        this.loginTitle = new System.Windows.Forms.Label();
        this.usernameLabel = new System.Windows.Forms.Label();
        this.username = new System.Windows.Forms.TextBox();
        this.adminPasswordLabel = new System.Windows.Forms.Label();
        this.adminPassword = new System.Windows.Forms.TextBox();
        this.previewConsole = new System.Windows.Forms.Button();
        this.securityNotice = new System.Windows.Forms.Label();
        this.loginHome = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // header
        this.header.Name = "header";
        this.header.Location = new System.Drawing.Point(0, 0);
        this.header.Size = new System.Drawing.Size(1140, 103);
        this.header.Dock = System.Windows.Forms.DockStyle.Top;
        this.header.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);

        // footer
        this.footer.Name = "footer";
        this.footer.Location = new System.Drawing.Point(0, 724);
        this.footer.Size = new System.Drawing.Size(1140, 36);
        this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.footer.BackColor = System.Drawing.Color.FromArgb(105, 75, 54);

        // body
        this.body.Name = "body";
        this.body.Location = new System.Drawing.Point(0, 103);
        this.body.Size = new System.Drawing.Size(1140, 621);
        this.body.Dock = System.Windows.Forms.DockStyle.Fill;
        this.body.BackColor = System.Drawing.Color.FromArgb(251, 247, 237);
        this.body.AutoScroll = true;
        this.body.AutoScrollMinSize = new System.Drawing.Size(1120, 715);

        // brand
        this.brand.Name = "brand";
        this.brand.Location = new System.Drawing.Point(30, 13);
        this.brand.Size = new System.Drawing.Size(430, 39);
        this.brand.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.brand.Text = "Olive Branch Bakes";
        this.brand.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
        this.brand.AutoSize = false;
        this.brand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // tagline
        this.tagline.Name = "tagline";
        this.tagline.Location = new System.Drawing.Point(33, 56);
        this.tagline.Size = new System.Drawing.Size(450, 25);
        this.tagline.ForeColor = System.Drawing.Color.FromArgb(251, 236, 200);
        this.tagline.Text = "SMALL BATCH  •  MADE WITH CARE";
        this.tagline.Font = new System.Drawing.Font("Segoe UI", 9.1F, System.Drawing.FontStyle.Bold);
        this.tagline.AutoSize = false;
        this.tagline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // nav0
        this.nav0.Name = "nav0";
        this.nav0.Location = new System.Drawing.Point(557, 28);
        this.nav0.Size = new System.Drawing.Size(107, 50);
        this.nav0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.nav0.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.nav0.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nav0.Text = "WELCOME";
        this.nav0.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
        this.nav0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.nav0.FlatAppearance.BorderSize = 0;
        this.nav0.UseVisualStyleBackColor = false;
        this.nav0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.nav0.TabIndex = 0;
        this.nav0.Tag = "Welcome";
        this.nav0.Click += new System.EventHandler(this.Navigate_Click);

        // nav1
        this.nav1.Name = "nav1";
        this.nav1.Location = new System.Drawing.Point(669, 28);
        this.nav1.Size = new System.Drawing.Size(107, 50);
        this.nav1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.nav1.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.nav1.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nav1.Text = "ORDER";
        this.nav1.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
        this.nav1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.nav1.FlatAppearance.BorderSize = 0;
        this.nav1.UseVisualStyleBackColor = false;
        this.nav1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.nav1.TabIndex = 1;
        this.nav1.Tag = "CustomerOrder";
        this.nav1.Click += new System.EventHandler(this.Navigate_Click);

        // nav2
        this.nav2.Name = "nav2";
        this.nav2.Location = new System.Drawing.Point(781, 28);
        this.nav2.Size = new System.Drawing.Size(107, 50);
        this.nav2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.nav2.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.nav2.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nav2.Text = "ACCOUNT";
        this.nav2.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
        this.nav2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.nav2.FlatAppearance.BorderSize = 0;
        this.nav2.UseVisualStyleBackColor = false;
        this.nav2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.nav2.TabIndex = 2;
        this.nav2.Tag = "CustomerAccount";
        this.nav2.Click += new System.EventHandler(this.Navigate_Click);

        // nav3
        this.nav3.Name = "nav3";
        this.nav3.Location = new System.Drawing.Point(893, 28);
        this.nav3.Size = new System.Drawing.Size(107, 50);
        this.nav3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.nav3.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.nav3.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nav3.Text = "SUMMARY";
        this.nav3.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
        this.nav3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.nav3.FlatAppearance.BorderSize = 0;
        this.nav3.UseVisualStyleBackColor = false;
        this.nav3.Cursor = System.Windows.Forms.Cursors.Hand;
        this.nav3.TabIndex = 3;
        this.nav3.Tag = "OrderSummary";
        this.nav3.Click += new System.EventHandler(this.Navigate_Click);

        // nav4
        this.nav4.Name = "nav4";
        this.nav4.Location = new System.Drawing.Point(1005, 28);
        this.nav4.Size = new System.Drawing.Size(107, 50);
        this.nav4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.nav4.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
        this.nav4.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nav4.Text = "STAFF";
        this.nav4.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
        this.nav4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.nav4.FlatAppearance.BorderSize = 0;
        this.nav4.UseVisualStyleBackColor = false;
        this.nav4.Cursor = System.Windows.Forms.Cursors.Hand;
        this.nav4.TabIndex = 4;
        this.nav4.Tag = "AdministratorLogin";
        this.nav4.Click += new System.EventHandler(this.Navigate_Click);

        // footerLeft
        this.footerLeft.Name = "footerLeft";
        this.footerLeft.Location = new System.Drawing.Point(20, 7);
        this.footerLeft.Size = new System.Drawing.Size(580, 23);
        this.footerLeft.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.footerLeft.Text = "OLIVE BRANCH BAKES  •  PRE-ORDER SYSTEM";
        this.footerLeft.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold);
        this.footerLeft.AutoSize = false;
        this.footerLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // footerRight
        this.footerRight.Name = "footerRight";
        this.footerRight.Location = new System.Drawing.Point(660, 7);
        this.footerRight.Size = new System.Drawing.Size(450, 23);
        this.footerRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.footerRight.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.footerRight.Text = "Checkout is not available yet";
        this.footerRight.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Regular);
        this.footerRight.AutoSize = false;
        this.footerRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // pageTitle
        this.pageTitle.Name = "pageTitle";
        this.pageTitle.Location = new System.Drawing.Point(39, 25);
        this.pageTitle.Size = new System.Drawing.Size(1010, 43);
        this.pageTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.pageTitle.Text = "Staff sign-in";
        this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
        this.pageTitle.AutoSize = false;
        this.pageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // pageSubtitle
        this.pageSubtitle.Name = "pageSubtitle";
        this.pageSubtitle.Location = new System.Drawing.Point(41, 67);
        this.pageSubtitle.Size = new System.Drawing.Size(1026, 28);
        this.pageSubtitle.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.pageSubtitle.Text = "Administrator sign-in is not available in this version.";
        this.pageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.pageSubtitle.AutoSize = false;
        this.pageSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // loginPanel
        this.loginPanel.Name = "loginPanel";
        this.loginPanel.Location = new System.Drawing.Point(221, 123);
        this.loginPanel.Size = new System.Drawing.Size(700, 425);
        this.loginPanel.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // loginTitle
        this.loginTitle.Name = "loginTitle";
        this.loginTitle.Location = new System.Drawing.Point(37, 23);
        this.loginTitle.Size = new System.Drawing.Size(623, 48);
        this.loginTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.loginTitle.Text = "Welcome back, bakery team.";
        this.loginTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.loginTitle.AutoSize = false;
        this.loginTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // usernameLabel
        this.usernameLabel.Name = "usernameLabel";
        this.usernameLabel.Location = new System.Drawing.Point(38, 92);
        this.usernameLabel.Size = new System.Drawing.Size(259, 27);
        this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.usernameLabel.Text = "USERNAME";
        this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.usernameLabel.AutoSize = false;
        this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // username
        this.username.Name = "username";
        this.username.Location = new System.Drawing.Point(39, 125);
        this.username.Size = new System.Drawing.Size(621, 40);
        this.username.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.username.PlaceholderText = "Username";
        this.username.TabIndex = 5;

        // adminPasswordLabel
        this.adminPasswordLabel.Name = "adminPasswordLabel";
        this.adminPasswordLabel.Location = new System.Drawing.Point(38, 184);
        this.adminPasswordLabel.Size = new System.Drawing.Size(260, 29);
        this.adminPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.adminPasswordLabel.Text = "PASSWORD";
        this.adminPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.adminPasswordLabel.AutoSize = false;
        this.adminPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // adminPassword
        this.adminPassword.Name = "adminPassword";
        this.adminPassword.Location = new System.Drawing.Point(39, 218);
        this.adminPassword.Size = new System.Drawing.Size(621, 40);
        this.adminPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.adminPassword.UseSystemPasswordChar = true;
        this.adminPassword.PlaceholderText = "Password";
        this.adminPassword.TabIndex = 6;

        // previewConsole
        this.previewConsole.Name = "previewConsole";
        this.previewConsole.Location = new System.Drawing.Point(39, 286);
        this.previewConsole.Size = new System.Drawing.Size(621, 59);
        this.previewConsole.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);
        this.previewConsole.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.previewConsole.Text = "ADMIN CONSOLE (PREVIEW)  →";
        this.previewConsole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.previewConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.previewConsole.FlatAppearance.BorderSize = 0;
        this.previewConsole.UseVisualStyleBackColor = false;
        this.previewConsole.Cursor = System.Windows.Forms.Cursors.Hand;
        this.previewConsole.TabIndex = 7;
        this.previewConsole.Tag = "AdministratorConsole";
        this.previewConsole.Click += new System.EventHandler(this.Navigate_Click);

        // securityNotice
        this.securityNotice.Name = "securityNotice";
        this.securityNotice.Location = new System.Drawing.Point(39, 353);
        this.securityNotice.Size = new System.Drawing.Size(621, 48);
        this.securityNotice.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.securityNotice.Text = "The console opens directly for the demonstration. Real authentication and authorization will be implemented later.";
        this.securityNotice.Font = new System.Drawing.Font("Segoe UI", 9.7F, System.Drawing.FontStyle.Regular);
        this.securityNotice.AutoSize = false;
        this.securityNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // loginHome
        this.loginHome.Name = "loginHome";
        this.loginHome.Location = new System.Drawing.Point(221, 568);
        this.loginHome.Size = new System.Drawing.Size(246, 52);
        this.loginHome.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.loginHome.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.loginHome.Text = "BACK TO WELCOME";
        this.loginHome.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        this.loginHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.loginHome.FlatAppearance.BorderSize = 0;
        this.loginHome.UseVisualStyleBackColor = false;
        this.loginHome.Cursor = System.Windows.Forms.Cursors.Hand;
        this.loginHome.TabIndex = 8;
        this.loginHome.Tag = "Welcome";
        this.loginHome.Click += new System.EventHandler(this.Navigate_Click);

        this.header.Controls.Add(this.brand);
        this.header.Controls.Add(this.tagline);
        this.header.Controls.Add(this.nav0);
        this.header.Controls.Add(this.nav1);
        this.header.Controls.Add(this.nav2);
        this.header.Controls.Add(this.nav3);
        this.header.Controls.Add(this.nav4);
        this.footer.Controls.Add(this.footerLeft);
        this.footer.Controls.Add(this.footerRight);
        this.body.Controls.Add(this.pageTitle);
        this.body.Controls.Add(this.pageSubtitle);
        this.body.Controls.Add(this.loginPanel);
        this.body.Controls.Add(this.loginHome);
        this.loginPanel.Controls.Add(this.loginTitle);
        this.loginPanel.Controls.Add(this.usernameLabel);
        this.loginPanel.Controls.Add(this.username);
        this.loginPanel.Controls.Add(this.adminPasswordLabel);
        this.loginPanel.Controls.Add(this.adminPassword);
        this.loginPanel.Controls.Add(this.previewConsole);
        this.loginPanel.Controls.Add(this.securityNotice);

        // Form
        this.Name = "AdministratorLoginForm";
        this.Text = "Olive Branch Bakes — Administrator Login";
        this.ClientSize = new System.Drawing.Size(1140, 760);
        this.MinimumSize = new System.Drawing.Size(955, 670);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.BackColor = System.Drawing.Color.FromArgb(251, 247, 237);
        this.Controls.Add(this.body);
        this.Controls.Add(this.footer);
        this.Controls.Add(this.header);
        this.ResumeLayout(false);
    }
}
