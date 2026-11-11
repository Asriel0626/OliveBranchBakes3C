namespace OliveBranchBakes.Forms;

partial class WelcomeForm
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
    private System.Windows.Forms.Panel heroCard = null!;
    private System.Windows.Forms.Label heroEyebrow = null!;
    private System.Windows.Forms.Label heroTitle = null!;
    private System.Windows.Forms.Label heroDesc = null!;
    private System.Windows.Forms.Button startOrder = null!;
    private System.Windows.Forms.Button accountNow = null!;
    private System.Windows.Forms.PictureBox heroPicture = null!;
    private System.Windows.Forms.Panel featurePanel0 = null!;
    private System.Windows.Forms.Label featureNumber0 = null!;
    private System.Windows.Forms.Label featureTitle0 = null!;
    private System.Windows.Forms.Label featureDescription0 = null!;
    private System.Windows.Forms.Panel featurePanel1 = null!;
    private System.Windows.Forms.Label featureNumber1 = null!;
    private System.Windows.Forms.Label featureTitle1 = null!;
    private System.Windows.Forms.Label featureDescription1 = null!;
    private System.Windows.Forms.Panel featurePanel2 = null!;
    private System.Windows.Forms.Label featureNumber2 = null!;
    private System.Windows.Forms.Label featureTitle2 = null!;
    private System.Windows.Forms.Label featureDescription2 = null!;
    private System.Windows.Forms.Button projectInfo = null!;
    private System.Windows.Forms.Label phaseNotice = null!;

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
        this.heroCard = new System.Windows.Forms.Panel();
        this.heroEyebrow = new System.Windows.Forms.Label();
        this.heroTitle = new System.Windows.Forms.Label();
        this.heroDesc = new System.Windows.Forms.Label();
        this.startOrder = new System.Windows.Forms.Button();
        this.accountNow = new System.Windows.Forms.Button();
        this.heroPicture = new System.Windows.Forms.PictureBox();
        this.featurePanel0 = new System.Windows.Forms.Panel();
        this.featureNumber0 = new System.Windows.Forms.Label();
        this.featureTitle0 = new System.Windows.Forms.Label();
        this.featureDescription0 = new System.Windows.Forms.Label();
        this.featurePanel1 = new System.Windows.Forms.Panel();
        this.featureNumber1 = new System.Windows.Forms.Label();
        this.featureTitle1 = new System.Windows.Forms.Label();
        this.featureDescription1 = new System.Windows.Forms.Label();
        this.featurePanel2 = new System.Windows.Forms.Panel();
        this.featureNumber2 = new System.Windows.Forms.Label();
        this.featureTitle2 = new System.Windows.Forms.Label();
        this.featureDescription2 = new System.Windows.Forms.Label();
        this.projectInfo = new System.Windows.Forms.Button();
        this.phaseNotice = new System.Windows.Forms.Label();
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
        this.nav0.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
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
        this.pageTitle.Text = "Welcome to our cottage kitchen";
        this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
        this.pageTitle.AutoSize = false;
        this.pageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // pageSubtitle
        this.pageSubtitle.Name = "pageSubtitle";
        this.pageSubtitle.Location = new System.Drawing.Point(41, 67);
        this.pageSubtitle.Size = new System.Drawing.Size(1026, 28);
        this.pageSubtitle.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.pageSubtitle.Text = "Freshly baked favorites, ready for your next celebration.";
        this.pageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.pageSubtitle.AutoSize = false;
        this.pageSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // heroCard
        this.heroCard.Name = "heroCard";
        this.heroCard.Location = new System.Drawing.Point(39, 119);
        this.heroCard.Size = new System.Drawing.Size(1058, 308);
        this.heroCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.heroCard.BackColor = System.Drawing.Color.FromArgb(251, 236, 200);

        // heroEyebrow
        this.heroEyebrow.Name = "heroEyebrow";
        this.heroEyebrow.Location = new System.Drawing.Point(27, 25);
        this.heroEyebrow.Size = new System.Drawing.Size(555, 31);
        this.heroEyebrow.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.heroEyebrow.Text = "FROM OUR HOME TO YOUR TABLE";
        this.heroEyebrow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.heroEyebrow.AutoSize = false;
        this.heroEyebrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // heroTitle
        this.heroTitle.Name = "heroTitle";
        this.heroTitle.Location = new System.Drawing.Point(27, 65);
        this.heroTitle.Size = new System.Drawing.Size(575, 110);
        this.heroTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.heroTitle.Text = "Baked slowly.\nShared with love.";
        this.heroTitle.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
        this.heroTitle.AutoSize = false;
        this.heroTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // heroDesc
        this.heroDesc.Name = "heroDesc";
        this.heroDesc.Location = new System.Drawing.Point(28, 173);
        this.heroDesc.Size = new System.Drawing.Size(575, 32);
        this.heroDesc.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.heroDesc.Text = "Explore small-batch breads, pastries and seasonal treats.";
        this.heroDesc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.heroDesc.AutoSize = false;
        this.heroDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // startOrder
        this.startOrder.Name = "startOrder";
        this.startOrder.Location = new System.Drawing.Point(27, 221);
        this.startOrder.Size = new System.Drawing.Size(237, 51);
        this.startOrder.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);
        this.startOrder.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.startOrder.Text = "EXPLORE THE MENU  →";
        this.startOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.startOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.startOrder.FlatAppearance.BorderSize = 0;
        this.startOrder.UseVisualStyleBackColor = false;
        this.startOrder.Cursor = System.Windows.Forms.Cursors.Hand;
        this.startOrder.TabIndex = 5;
        this.startOrder.Tag = "CustomerOrder";
        this.startOrder.Click += new System.EventHandler(this.Navigate_Click);

        // accountNow
        this.accountNow.Name = "accountNow";
        this.accountNow.Location = new System.Drawing.Point(275, 221);
        this.accountNow.Size = new System.Drawing.Size(181, 51);
        this.accountNow.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.accountNow.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.accountNow.Text = "MY ACCOUNT";
        this.accountNow.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        this.accountNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.accountNow.FlatAppearance.BorderSize = 0;
        this.accountNow.UseVisualStyleBackColor = false;
        this.accountNow.Cursor = System.Windows.Forms.Cursors.Hand;
        this.accountNow.TabIndex = 6;
        this.accountNow.Tag = "CustomerAccount";
        this.accountNow.Click += new System.EventHandler(this.Navigate_Click);

        // heroPicture
        this.heroPicture.Name = "heroPicture";
        this.heroPicture.Location = new System.Drawing.Point(660, 10);
        this.heroPicture.Size = new System.Drawing.Size(337, 256);
        this.heroPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.heroPicture.BackColor = System.Drawing.Color.FromArgb(251, 247, 237);
        this.heroPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

        // featurePanel0
        this.featurePanel0.Name = "featurePanel0";
        this.featurePanel0.Location = new System.Drawing.Point(39, 454);
        this.featurePanel0.Size = new System.Drawing.Size(340, 125);
        this.featurePanel0.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.featurePanel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // featureNumber0
        this.featureNumber0.Name = "featureNumber0";
        this.featureNumber0.Location = new System.Drawing.Point(18, 9);
        this.featureNumber0.Size = new System.Drawing.Size(293, 28);
        this.featureNumber0.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.featureNumber0.Text = "01  CHOOSE";
        this.featureNumber0.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.featureNumber0.AutoSize = false;
        this.featureNumber0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureTitle0
        this.featureTitle0.Name = "featureTitle0";
        this.featureTitle0.Location = new System.Drawing.Point(18, 39);
        this.featureTitle0.Size = new System.Drawing.Size(294, 37);
        this.featureTitle0.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.featureTitle0.Text = "Browse baked goods";
        this.featureTitle0.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.featureTitle0.AutoSize = false;
        this.featureTitle0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureDescription0
        this.featureDescription0.Name = "featureDescription0";
        this.featureDescription0.Location = new System.Drawing.Point(18, 80);
        this.featureDescription0.Size = new System.Drawing.Size(294, 29);
        this.featureDescription0.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.featureDescription0.Text = "Handmade breads, pastries, cookies.";
        this.featureDescription0.Font = new System.Drawing.Font("Segoe UI", 9.8F, System.Drawing.FontStyle.Regular);
        this.featureDescription0.AutoSize = false;
        this.featureDescription0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featurePanel1
        this.featurePanel1.Name = "featurePanel1";
        this.featurePanel1.Location = new System.Drawing.Point(398, 454);
        this.featurePanel1.Size = new System.Drawing.Size(340, 125);
        this.featurePanel1.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.featurePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // featureNumber1
        this.featureNumber1.Name = "featureNumber1";
        this.featureNumber1.Location = new System.Drawing.Point(18, 9);
        this.featureNumber1.Size = new System.Drawing.Size(293, 28);
        this.featureNumber1.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.featureNumber1.Text = "02  REVIEW";
        this.featureNumber1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.featureNumber1.AutoSize = false;
        this.featureNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureTitle1
        this.featureTitle1.Name = "featureTitle1";
        this.featureTitle1.Location = new System.Drawing.Point(18, 39);
        this.featureTitle1.Size = new System.Drawing.Size(294, 37);
        this.featureTitle1.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.featureTitle1.Text = "Plan your order";
        this.featureTitle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.featureTitle1.AutoSize = false;
        this.featureTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureDescription1
        this.featureDescription1.Name = "featureDescription1";
        this.featureDescription1.Location = new System.Drawing.Point(18, 80);
        this.featureDescription1.Size = new System.Drawing.Size(294, 29);
        this.featureDescription1.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.featureDescription1.Text = "Review the sample order summary.";
        this.featureDescription1.Font = new System.Drawing.Font("Segoe UI", 9.8F, System.Drawing.FontStyle.Regular);
        this.featureDescription1.AutoSize = false;
        this.featureDescription1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featurePanel2
        this.featurePanel2.Name = "featurePanel2";
        this.featurePanel2.Location = new System.Drawing.Point(757, 454);
        this.featurePanel2.Size = new System.Drawing.Size(340, 125);
        this.featurePanel2.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.featurePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // featureNumber2
        this.featureNumber2.Name = "featureNumber2";
        this.featureNumber2.Location = new System.Drawing.Point(18, 9);
        this.featureNumber2.Size = new System.Drawing.Size(293, 28);
        this.featureNumber2.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.featureNumber2.Text = "03  PICK UP";
        this.featureNumber2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.featureNumber2.AutoSize = false;
        this.featureNumber2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureTitle2
        this.featureTitle2.Name = "featureTitle2";
        this.featureTitle2.Location = new System.Drawing.Point(18, 39);
        this.featureTitle2.Size = new System.Drawing.Size(294, 37);
        this.featureTitle2.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.featureTitle2.Text = "See what comes next";
        this.featureTitle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.featureTitle2.AutoSize = false;
        this.featureTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // featureDescription2
        this.featureDescription2.Name = "featureDescription2";
        this.featureDescription2.Location = new System.Drawing.Point(18, 80);
        this.featureDescription2.Size = new System.Drawing.Size(294, 29);
        this.featureDescription2.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.featureDescription2.Text = "Designed for easy touchscreen use.";
        this.featureDescription2.Font = new System.Drawing.Font("Segoe UI", 9.8F, System.Drawing.FontStyle.Regular);
        this.featureDescription2.AutoSize = false;
        this.featureDescription2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // projectInfo
        this.projectInfo.Name = "projectInfo";
        this.projectInfo.Location = new System.Drawing.Point(40, 595);
        this.projectInfo.Size = new System.Drawing.Size(255, 47);
        this.projectInfo.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.projectInfo.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.projectInfo.Text = "PROJECT INFORMATION";
        this.projectInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.projectInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.projectInfo.FlatAppearance.BorderSize = 0;
        this.projectInfo.UseVisualStyleBackColor = false;
        this.projectInfo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.projectInfo.TabIndex = 7;
        this.projectInfo.Click += new System.EventHandler(this.ProjectInfo_Click);

        // phaseNotice
        this.phaseNotice.Name = "phaseNotice";
        this.phaseNotice.Location = new System.Drawing.Point(310, 596);
        this.phaseNotice.Size = new System.Drawing.Size(700, 41);
        this.phaseNotice.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.phaseNotice.Text = "Prototype only  •  No real products are sold or payments taken.";
        this.phaseNotice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
        this.phaseNotice.AutoSize = false;
        this.phaseNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

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
        this.body.Controls.Add(this.heroCard);
        this.body.Controls.Add(this.featurePanel0);
        this.body.Controls.Add(this.featurePanel1);
        this.body.Controls.Add(this.featurePanel2);
        this.body.Controls.Add(this.projectInfo);
        this.body.Controls.Add(this.phaseNotice);
        this.heroCard.Controls.Add(this.heroEyebrow);
        this.heroCard.Controls.Add(this.heroTitle);
        this.heroCard.Controls.Add(this.heroDesc);
        this.heroCard.Controls.Add(this.startOrder);
        this.heroCard.Controls.Add(this.accountNow);
        this.heroCard.Controls.Add(this.heroPicture);
        this.featurePanel0.Controls.Add(this.featureNumber0);
        this.featurePanel0.Controls.Add(this.featureTitle0);
        this.featurePanel0.Controls.Add(this.featureDescription0);
        this.featurePanel1.Controls.Add(this.featureNumber1);
        this.featurePanel1.Controls.Add(this.featureTitle1);
        this.featurePanel1.Controls.Add(this.featureDescription1);
        this.featurePanel2.Controls.Add(this.featureNumber2);
        this.featurePanel2.Controls.Add(this.featureTitle2);
        this.featurePanel2.Controls.Add(this.featureDescription2);

        // Form
        this.Name = "WelcomeForm";
        this.Text = "Olive Branch Bakes — Welcome";
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
