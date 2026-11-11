namespace OliveBranchBakes.Forms;

partial class CustomerAccountForm
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
    private System.Windows.Forms.Panel accountCard = null!;
    private System.Windows.Forms.Label accountHeader = null!;
    private System.Windows.Forms.Label firstNameLabel = null!;
    private System.Windows.Forms.TextBox fullName = null!;
    private System.Windows.Forms.Label emailLabel = null!;
    private System.Windows.Forms.TextBox email = null!;
    private System.Windows.Forms.Label passwordLabel = null!;
    private System.Windows.Forms.TextBox password = null!;
    private System.Windows.Forms.Button signIn = null!;
    private System.Windows.Forms.Button register = null!;
    private System.Windows.Forms.Panel accountRight = null!;
    private System.Windows.Forms.Label accountRightTitle = null!;
    private System.Windows.Forms.Label accountRightText = null!;
    private System.Windows.Forms.Button accountSummary = null!;
    private System.Windows.Forms.Label accountBottom = null!;

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
        this.accountCard = new System.Windows.Forms.Panel();
        this.accountHeader = new System.Windows.Forms.Label();
        this.firstNameLabel = new System.Windows.Forms.Label();
        this.fullName = new System.Windows.Forms.TextBox();
        this.emailLabel = new System.Windows.Forms.Label();
        this.email = new System.Windows.Forms.TextBox();
        this.passwordLabel = new System.Windows.Forms.Label();
        this.password = new System.Windows.Forms.TextBox();
        this.signIn = new System.Windows.Forms.Button();
        this.register = new System.Windows.Forms.Button();
        this.accountRight = new System.Windows.Forms.Panel();
        this.accountRightTitle = new System.Windows.Forms.Label();
        this.accountRightText = new System.Windows.Forms.Label();
        this.accountSummary = new System.Windows.Forms.Button();
        this.accountBottom = new System.Windows.Forms.Label();
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
        this.nav2.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
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
        this.nav4.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
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
        this.pageTitle.Text = "A familiar place for your details";
        this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
        this.pageTitle.AutoSize = false;
        this.pageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // pageSubtitle
        this.pageSubtitle.Name = "pageSubtitle";
        this.pageSubtitle.Location = new System.Drawing.Point(41, 67);
        this.pageSubtitle.Size = new System.Drawing.Size(1026, 28);
        this.pageSubtitle.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.pageSubtitle.Text = "Account/login interface only • information entered here is not saved, checked, or sent anywhere.";
        this.pageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.pageSubtitle.AutoSize = false;
        this.pageSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // accountCard
        this.accountCard.Name = "accountCard";
        this.accountCard.Location = new System.Drawing.Point(39, 117);
        this.accountCard.Size = new System.Drawing.Size(649, 438);
        this.accountCard.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.accountCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // accountHeader
        this.accountHeader.Name = "accountHeader";
        this.accountHeader.Location = new System.Drawing.Point(22, 18);
        this.accountHeader.Size = new System.Drawing.Size(605, 40);
        this.accountHeader.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.accountHeader.Text = "Customer account";
        this.accountHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.accountHeader.AutoSize = false;
        this.accountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // firstNameLabel
        this.firstNameLabel.Name = "firstNameLabel";
        this.firstNameLabel.Location = new System.Drawing.Point(25, 78);
        this.firstNameLabel.Size = new System.Drawing.Size(211, 27);
        this.firstNameLabel.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.firstNameLabel.Text = "FULL NAME";
        this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.firstNameLabel.AutoSize = false;
        this.firstNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // fullName
        this.fullName.Name = "fullName";
        this.fullName.Location = new System.Drawing.Point(25, 111);
        this.fullName.Size = new System.Drawing.Size(595, 37);
        this.fullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.fullName.PlaceholderText = "Enter your name (not saved)";
        this.fullName.TabIndex = 5;

        // emailLabel
        this.emailLabel.Name = "emailLabel";
        this.emailLabel.Location = new System.Drawing.Point(25, 168);
        this.emailLabel.Size = new System.Drawing.Size(226, 27);
        this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.emailLabel.Text = "EMAIL ADDRESS";
        this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.emailLabel.AutoSize = false;
        this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // email
        this.email.Name = "email";
        this.email.Location = new System.Drawing.Point(25, 199);
        this.email.Size = new System.Drawing.Size(595, 37);
        this.email.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.email.PlaceholderText = "you@example.com (not saved)";
        this.email.TabIndex = 6;

        // passwordLabel
        this.passwordLabel.Name = "passwordLabel";
        this.passwordLabel.Location = new System.Drawing.Point(25, 255);
        this.passwordLabel.Size = new System.Drawing.Size(221, 28);
        this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.passwordLabel.Text = "PASSWORD";
        this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.passwordLabel.AutoSize = false;
        this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // password
        this.password.Name = "password";
        this.password.Location = new System.Drawing.Point(25, 286);
        this.password.Size = new System.Drawing.Size(595, 37);
        this.password.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.password.UseSystemPasswordChar = true;
        this.password.PlaceholderText = "Password";
        this.password.TabIndex = 7;

        // signIn
        this.signIn.Name = "signIn";
        this.signIn.Location = new System.Drawing.Point(25, 351);
        this.signIn.Size = new System.Drawing.Size(278, 55);
        this.signIn.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);
        this.signIn.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.signIn.Text = "SIGN IN (PREVIEW)";
        this.signIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.signIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.signIn.FlatAppearance.BorderSize = 0;
        this.signIn.UseVisualStyleBackColor = false;
        this.signIn.Cursor = System.Windows.Forms.Cursors.Hand;
        this.signIn.TabIndex = 8;
        this.signIn.Click += new System.EventHandler(this.PreviewOnly_Click);

        // register
        this.register.Name = "register";
        this.register.Location = new System.Drawing.Point(319, 351);
        this.register.Size = new System.Drawing.Size(300, 55);
        this.register.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
        this.register.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.register.Text = "CREATE ACCOUNT (PREVIEW)";
        this.register.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.register.FlatAppearance.BorderSize = 0;
        this.register.UseVisualStyleBackColor = false;
        this.register.Cursor = System.Windows.Forms.Cursors.Hand;
        this.register.TabIndex = 9;
        this.register.Click += new System.EventHandler(this.PreviewOnly_Click);

        // accountRight
        this.accountRight.Name = "accountRight";
        this.accountRight.Location = new System.Drawing.Point(717, 117);
        this.accountRight.Size = new System.Drawing.Size(382, 438);
        this.accountRight.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.accountRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // accountRightTitle
        this.accountRightTitle.Name = "accountRightTitle";
        this.accountRightTitle.Location = new System.Drawing.Point(20, 24);
        this.accountRightTitle.Size = new System.Drawing.Size(333, 43);
        this.accountRightTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.accountRightTitle.Text = "Why an account?";
        this.accountRightTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.accountRightTitle.AutoSize = false;
        this.accountRightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // accountRightText
        this.accountRightText.Name = "accountRightText";
        this.accountRightText.Location = new System.Drawing.Point(22, 85);
        this.accountRightText.Size = new System.Drawing.Size(332, 244);
        this.accountRightText.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.accountRightText.Text = "• Remember contact details\n\n• View future orders\n\n• Check pickup preferences\n\n• Enjoy an easy, touch-friendly experience";
        this.accountRightText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.accountRightText.AutoSize = false;
        this.accountRightText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // accountSummary
        this.accountSummary.Name = "accountSummary";
        this.accountSummary.Location = new System.Drawing.Point(21, 347);
        this.accountSummary.Size = new System.Drawing.Size(337, 55);
        this.accountSummary.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.accountSummary.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.accountSummary.Text = "GO TO ORDER SUMMARY";
        this.accountSummary.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        this.accountSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.accountSummary.FlatAppearance.BorderSize = 0;
        this.accountSummary.UseVisualStyleBackColor = false;
        this.accountSummary.Cursor = System.Windows.Forms.Cursors.Hand;
        this.accountSummary.TabIndex = 10;
        this.accountSummary.Tag = "OrderSummary";
        this.accountSummary.Click += new System.EventHandler(this.Navigate_Click);

        // accountBottom
        this.accountBottom.Name = "accountBottom";
        this.accountBottom.Location = new System.Drawing.Point(40, 572);
        this.accountBottom.Size = new System.Drawing.Size(1020, 39);
        this.accountBottom.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.accountBottom.Text = "Clear labels  •  Large tap targets  •  Logical keyboard tab order";
        this.accountBottom.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.accountBottom.AutoSize = false;
        this.accountBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

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
        this.body.Controls.Add(this.accountCard);
        this.body.Controls.Add(this.accountRight);
        this.body.Controls.Add(this.accountBottom);
        this.accountCard.Controls.Add(this.accountHeader);
        this.accountCard.Controls.Add(this.firstNameLabel);
        this.accountCard.Controls.Add(this.fullName);
        this.accountCard.Controls.Add(this.emailLabel);
        this.accountCard.Controls.Add(this.email);
        this.accountCard.Controls.Add(this.passwordLabel);
        this.accountCard.Controls.Add(this.password);
        this.accountCard.Controls.Add(this.signIn);
        this.accountCard.Controls.Add(this.register);
        this.accountRight.Controls.Add(this.accountRightTitle);
        this.accountRight.Controls.Add(this.accountRightText);
        this.accountRight.Controls.Add(this.accountSummary);

        // Form
        this.Name = "CustomerAccountForm";
        this.Text = "Olive Branch Bakes — Customer Account";
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
