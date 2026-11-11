namespace OliveBranchBakes.Forms;

partial class AdministratorConsoleForm
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
    private System.Windows.Forms.Panel metric0 = null!;
    private System.Windows.Forms.Label metricHeading0 = null!;
    private System.Windows.Forms.Label metricValue0 = null!;
    private System.Windows.Forms.Label metricDesc0 = null!;
    private System.Windows.Forms.Panel metric1 = null!;
    private System.Windows.Forms.Label metricHeading1 = null!;
    private System.Windows.Forms.Label metricValue1 = null!;
    private System.Windows.Forms.Label metricDesc1 = null!;
    private System.Windows.Forms.Panel metric2 = null!;
    private System.Windows.Forms.Label metricHeading2 = null!;
    private System.Windows.Forms.Label metricValue2 = null!;
    private System.Windows.Forms.Label metricDesc2 = null!;
    private System.Windows.Forms.Panel adminTasks = null!;
    private System.Windows.Forms.Label taskTitle = null!;
    private System.Windows.Forms.Label taskDetail = null!;
    private System.Windows.Forms.Button ordersTask = null!;
    private System.Windows.Forms.Button stockTask = null!;
    private System.Windows.Forms.Button staffTask = null!;
    private System.Windows.Forms.Button logout = null!;
    private System.Windows.Forms.Label securityNext = null!;

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
        this.metric0 = new System.Windows.Forms.Panel();
        this.metricHeading0 = new System.Windows.Forms.Label();
        this.metricValue0 = new System.Windows.Forms.Label();
        this.metricDesc0 = new System.Windows.Forms.Label();
        this.metric1 = new System.Windows.Forms.Panel();
        this.metricHeading1 = new System.Windows.Forms.Label();
        this.metricValue1 = new System.Windows.Forms.Label();
        this.metricDesc1 = new System.Windows.Forms.Label();
        this.metric2 = new System.Windows.Forms.Panel();
        this.metricHeading2 = new System.Windows.Forms.Label();
        this.metricValue2 = new System.Windows.Forms.Label();
        this.metricDesc2 = new System.Windows.Forms.Label();
        this.adminTasks = new System.Windows.Forms.Panel();
        this.taskTitle = new System.Windows.Forms.Label();
        this.taskDetail = new System.Windows.Forms.Label();
        this.ordersTask = new System.Windows.Forms.Button();
        this.stockTask = new System.Windows.Forms.Button();
        this.staffTask = new System.Windows.Forms.Button();
        this.logout = new System.Windows.Forms.Button();
        this.securityNext = new System.Windows.Forms.Label();
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
        this.pageTitle.Text = "Bakery operations overview";
        this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
        this.pageTitle.AutoSize = false;
        this.pageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // pageSubtitle
        this.pageSubtitle.Name = "pageSubtitle";
        this.pageSubtitle.Location = new System.Drawing.Point(41, 67);
        this.pageSubtitle.Size = new System.Drawing.Size(1026, 28);
        this.pageSubtitle.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.pageSubtitle.Text = "Administrator console prototype • sample data only. Staff tasks will become functional in later phases.";
        this.pageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.pageSubtitle.AutoSize = false;
        this.pageSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metric0
        this.metric0.Name = "metric0";
        this.metric0.Location = new System.Drawing.Point(40, 125);
        this.metric0.Size = new System.Drawing.Size(339, 145);
        this.metric0.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.metric0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // metricHeading0
        this.metricHeading0.Name = "metricHeading0";
        this.metricHeading0.Location = new System.Drawing.Point(22, 19);
        this.metricHeading0.Size = new System.Drawing.Size(290, 32);
        this.metricHeading0.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.metricHeading0.Text = "NEW ORDERS";
        this.metricHeading0.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Bold);
        this.metricHeading0.AutoSize = false;
        this.metricHeading0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricValue0
        this.metricValue0.Name = "metricValue0";
        this.metricValue0.Location = new System.Drawing.Point(21, 52);
        this.metricValue0.Size = new System.Drawing.Size(90, 49);
        this.metricValue0.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.metricValue0.Text = "—";
        this.metricValue0.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
        this.metricValue0.AutoSize = false;
        this.metricValue0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricDesc0
        this.metricDesc0.Name = "metricDesc0";
        this.metricDesc0.Location = new System.Drawing.Point(21, 104);
        this.metricDesc0.Size = new System.Drawing.Size(294, 28);
        this.metricDesc0.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.metricDesc0.Text = "No live orders yet";
        this.metricDesc0.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
        this.metricDesc0.AutoSize = false;
        this.metricDesc0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metric1
        this.metric1.Name = "metric1";
        this.metric1.Location = new System.Drawing.Point(400, 125);
        this.metric1.Size = new System.Drawing.Size(339, 145);
        this.metric1.BackColor = System.Drawing.Color.FromArgb(251, 236, 200);
        this.metric1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // metricHeading1
        this.metricHeading1.Name = "metricHeading1";
        this.metricHeading1.Location = new System.Drawing.Point(22, 19);
        this.metricHeading1.Size = new System.Drawing.Size(290, 32);
        this.metricHeading1.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.metricHeading1.Text = "PICKUP QUEUE";
        this.metricHeading1.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Bold);
        this.metricHeading1.AutoSize = false;
        this.metricHeading1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricValue1
        this.metricValue1.Name = "metricValue1";
        this.metricValue1.Location = new System.Drawing.Point(21, 52);
        this.metricValue1.Size = new System.Drawing.Size(90, 49);
        this.metricValue1.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.metricValue1.Text = "—";
        this.metricValue1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
        this.metricValue1.AutoSize = false;
        this.metricValue1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricDesc1
        this.metricDesc1.Name = "metricDesc1";
        this.metricDesc1.Location = new System.Drawing.Point(21, 104);
        this.metricDesc1.Size = new System.Drawing.Size(294, 28);
        this.metricDesc1.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.metricDesc1.Text = "No pickups scheduled";
        this.metricDesc1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
        this.metricDesc1.AutoSize = false;
        this.metricDesc1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metric2
        this.metric2.Name = "metric2";
        this.metric2.Location = new System.Drawing.Point(760, 125);
        this.metric2.Size = new System.Drawing.Size(339, 145);
        this.metric2.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.metric2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // metricHeading2
        this.metricHeading2.Name = "metricHeading2";
        this.metricHeading2.Location = new System.Drawing.Point(22, 19);
        this.metricHeading2.Size = new System.Drawing.Size(290, 32);
        this.metricHeading2.ForeColor = System.Drawing.Color.FromArgb(166, 104, 79);
        this.metricHeading2.Text = "MENU & STOCK";
        this.metricHeading2.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Bold);
        this.metricHeading2.AutoSize = false;
        this.metricHeading2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricValue2
        this.metricValue2.Name = "metricValue2";
        this.metricValue2.Location = new System.Drawing.Point(21, 52);
        this.metricValue2.Size = new System.Drawing.Size(90, 49);
        this.metricValue2.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.metricValue2.Text = "—";
        this.metricValue2.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
        this.metricValue2.AutoSize = false;
        this.metricValue2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // metricDesc2
        this.metricDesc2.Name = "metricDesc2";
        this.metricDesc2.Location = new System.Drawing.Point(21, 104);
        this.metricDesc2.Size = new System.Drawing.Size(294, 28);
        this.metricDesc2.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.metricDesc2.Text = "Sample products only";
        this.metricDesc2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
        this.metricDesc2.AutoSize = false;
        this.metricDesc2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // adminTasks
        this.adminTasks.Name = "adminTasks";
        this.adminTasks.Location = new System.Drawing.Point(40, 294);
        this.adminTasks.Size = new System.Drawing.Size(1059, 265);
        this.adminTasks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.adminTasks.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.adminTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // taskTitle
        this.taskTitle.Name = "taskTitle";
        this.taskTitle.Location = new System.Drawing.Point(25, 16);
        this.taskTitle.Size = new System.Drawing.Size(1004, 46);
        this.taskTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.taskTitle.Text = "Planned staff tools";
        this.taskTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.taskTitle.AutoSize = false;
        this.taskTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // taskDetail
        this.taskDetail.Name = "taskDetail";
        this.taskDetail.Location = new System.Drawing.Point(26, 73);
        this.taskDetail.Size = new System.Drawing.Size(1002, 58);
        this.taskDetail.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.taskDetail.Text = "These controls demonstrate the future administration layout. They do not update orders, products, or customer accounts.";
        this.taskDetail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular);
        this.taskDetail.AutoSize = false;
        this.taskDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // ordersTask
        this.ordersTask.Name = "ordersTask";
        this.ordersTask.Location = new System.Drawing.Point(28, 153);
        this.ordersTask.Size = new System.Drawing.Size(306, 59);
        this.ordersTask.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);
        this.ordersTask.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.ordersTask.Text = "VIEW ORDERS (PREVIEW)";
        this.ordersTask.Font = new System.Drawing.Font("Segoe UI", 10.6F, System.Drawing.FontStyle.Bold);
        this.ordersTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.ordersTask.FlatAppearance.BorderSize = 0;
        this.ordersTask.UseVisualStyleBackColor = false;
        this.ordersTask.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ordersTask.TabIndex = 5;
        this.ordersTask.Click += new System.EventHandler(this.PreviewOnly_Click);

        // stockTask
        this.stockTask.Name = "stockTask";
        this.stockTask.Location = new System.Drawing.Point(361, 153);
        this.stockTask.Size = new System.Drawing.Size(324, 59);
        this.stockTask.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
        this.stockTask.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.stockTask.Text = "MANAGE PRODUCTS (PREVIEW)";
        this.stockTask.Font = new System.Drawing.Font("Segoe UI", 10.6F, System.Drawing.FontStyle.Bold);
        this.stockTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.stockTask.FlatAppearance.BorderSize = 0;
        this.stockTask.UseVisualStyleBackColor = false;
        this.stockTask.Cursor = System.Windows.Forms.Cursors.Hand;
        this.stockTask.TabIndex = 6;
        this.stockTask.Click += new System.EventHandler(this.PreviewOnly_Click);

        // staffTask
        this.staffTask.Name = "staffTask";
        this.staffTask.Location = new System.Drawing.Point(709, 153);
        this.staffTask.Size = new System.Drawing.Size(321, 59);
        this.staffTask.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.staffTask.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.staffTask.Text = "PICKUP SCHEDULE (PREVIEW)";
        this.staffTask.Font = new System.Drawing.Font("Segoe UI", 10.6F, System.Drawing.FontStyle.Bold);
        this.staffTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.staffTask.FlatAppearance.BorderSize = 0;
        this.staffTask.UseVisualStyleBackColor = false;
        this.staffTask.Cursor = System.Windows.Forms.Cursors.Hand;
        this.staffTask.TabIndex = 7;
        this.staffTask.Click += new System.EventHandler(this.PreviewOnly_Click);

        // logout
        this.logout.Name = "logout";
        this.logout.Location = new System.Drawing.Point(40, 578);
        this.logout.Size = new System.Drawing.Size(266, 54);
        this.logout.BackColor = System.Drawing.Color.FromArgb(232, 238, 219);
        this.logout.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.logout.Text = "BACK TO STAFF LOGIN";
        this.logout.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Bold);
        this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.logout.FlatAppearance.BorderSize = 0;
        this.logout.UseVisualStyleBackColor = false;
        this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
        this.logout.TabIndex = 8;
        this.logout.Tag = "AdministratorLogin";
        this.logout.Click += new System.EventHandler(this.Navigate_Click);

        // securityNext
        this.securityNext.Name = "securityNext";
        this.securityNext.Location = new System.Drawing.Point(329, 583);
        this.securityNext.Size = new System.Drawing.Size(755, 44);
        this.securityNext.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.securityNext.Text = "Administrator controls will be added in a later update.";
        this.securityNext.Font = new System.Drawing.Font("Segoe UI", 10.4F, System.Drawing.FontStyle.Regular);
        this.securityNext.AutoSize = false;
        this.securityNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

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
        this.body.Controls.Add(this.metric0);
        this.body.Controls.Add(this.metric1);
        this.body.Controls.Add(this.metric2);
        this.body.Controls.Add(this.adminTasks);
        this.body.Controls.Add(this.logout);
        this.body.Controls.Add(this.securityNext);
        this.metric0.Controls.Add(this.metricHeading0);
        this.metric0.Controls.Add(this.metricValue0);
        this.metric0.Controls.Add(this.metricDesc0);
        this.metric1.Controls.Add(this.metricHeading1);
        this.metric1.Controls.Add(this.metricValue1);
        this.metric1.Controls.Add(this.metricDesc1);
        this.metric2.Controls.Add(this.metricHeading2);
        this.metric2.Controls.Add(this.metricValue2);
        this.metric2.Controls.Add(this.metricDesc2);
        this.adminTasks.Controls.Add(this.taskTitle);
        this.adminTasks.Controls.Add(this.taskDetail);
        this.adminTasks.Controls.Add(this.ordersTask);
        this.adminTasks.Controls.Add(this.stockTask);
        this.adminTasks.Controls.Add(this.staffTask);

        // Form
        this.Name = "AdministratorConsoleForm";
        this.Text = "Olive Branch Bakes — Administrator Console";
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
