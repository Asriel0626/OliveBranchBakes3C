namespace OliveBranchBakes.Forms;

partial class OrderSummaryForm
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
    private System.Windows.Forms.Panel summaryCard = null!;
    private System.Windows.Forms.Label summaryHeading = null!;
    private System.Windows.Forms.Panel emptyBox = null!;
    private System.Windows.Forms.Label emptyTitle = null!;
    private System.Windows.Forms.Label emptyDetail = null!;
    private System.Windows.Forms.Label plannedTotals = null!;
    private System.Windows.Forms.Panel nextCard = null!;
    private System.Windows.Forms.Label nextTitle = null!;
    private System.Windows.Forms.Label nextDescription = null!;
    private System.Windows.Forms.Button backMenu = null!;
    private System.Windows.Forms.Button summaryAccount = null!;
    private System.Windows.Forms.Button placePreview = null!;
    private System.Windows.Forms.Label placeDisclaimer = null!;

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
        this.summaryCard = new System.Windows.Forms.Panel();
        this.summaryHeading = new System.Windows.Forms.Label();
        this.emptyBox = new System.Windows.Forms.Panel();
        this.emptyTitle = new System.Windows.Forms.Label();
        this.emptyDetail = new System.Windows.Forms.Label();
        this.plannedTotals = new System.Windows.Forms.Label();
        this.nextCard = new System.Windows.Forms.Panel();
        this.nextTitle = new System.Windows.Forms.Label();
        this.nextDescription = new System.Windows.Forms.Label();
        this.backMenu = new System.Windows.Forms.Button();
        this.summaryAccount = new System.Windows.Forms.Button();
        this.placePreview = new System.Windows.Forms.Button();
        this.placeDisclaimer = new System.Windows.Forms.Label();
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
        this.nav3.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
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
        this.pageTitle.Text = "Your order, at a glance";
        this.pageTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
        this.pageTitle.AutoSize = false;
        this.pageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // pageSubtitle
        this.pageSubtitle.Name = "pageSubtitle";
        this.pageSubtitle.Location = new System.Drawing.Point(41, 67);
        this.pageSubtitle.Size = new System.Drawing.Size(1026, 28);
        this.pageSubtitle.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.pageSubtitle.Text = "Review your order details here when checkout becomes available.";
        this.pageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.pageSubtitle.AutoSize = false;
        this.pageSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // summaryCard
        this.summaryCard.Name = "summaryCard";
        this.summaryCard.Location = new System.Drawing.Point(40, 121);
        this.summaryCard.Size = new System.Drawing.Size(689, 440);
        this.summaryCard.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.summaryCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // summaryHeading
        this.summaryHeading.Name = "summaryHeading";
        this.summaryHeading.Location = new System.Drawing.Point(25, 20);
        this.summaryHeading.Size = new System.Drawing.Size(640, 48);
        this.summaryHeading.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.summaryHeading.Text = "Shopping cart preview";
        this.summaryHeading.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        this.summaryHeading.AutoSize = false;
        this.summaryHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // emptyBox
        this.emptyBox.Name = "emptyBox";
        this.emptyBox.Location = new System.Drawing.Point(24, 91);
        this.emptyBox.Size = new System.Drawing.Size(638, 177);
        this.emptyBox.BackColor = System.Drawing.Color.FromArgb(251, 247, 237);

        // emptyTitle
        this.emptyTitle.Name = "emptyTitle";
        this.emptyTitle.Location = new System.Drawing.Point(22, 22);
        this.emptyTitle.Size = new System.Drawing.Size(594, 56);
        this.emptyTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.emptyTitle.Text = "Nothing in the basket yet";
        this.emptyTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.emptyTitle.AutoSize = false;
        this.emptyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // emptyDetail
        this.emptyDetail.Name = "emptyDetail";
        this.emptyDetail.Location = new System.Drawing.Point(22, 84);
        this.emptyDetail.Size = new System.Drawing.Size(592, 66);
        this.emptyDetail.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.emptyDetail.Text = "No items have been added yet.\nCart and checkout will be available in a later update.";
        this.emptyDetail.Font = new System.Drawing.Font("Segoe UI", 10.3F, System.Drawing.FontStyle.Regular);
        this.emptyDetail.AutoSize = false;
        this.emptyDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // plannedTotals
        this.plannedTotals.Name = "plannedTotals";
        this.plannedTotals.Location = new System.Drawing.Point(26, 294);
        this.plannedTotals.Size = new System.Drawing.Size(610, 105);
        this.plannedTotals.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.plannedTotals.Text = "Subtotal                        --\nPickup window                Not selected\nOrder status                  Not placed";
        this.plannedTotals.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
        this.plannedTotals.AutoSize = false;
        this.plannedTotals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // nextCard
        this.nextCard.Name = "nextCard";
        this.nextCard.Location = new System.Drawing.Point(751, 121);
        this.nextCard.Size = new System.Drawing.Size(347, 440);
        this.nextCard.BackColor = System.Drawing.Color.FromArgb(251, 236, 200);
        this.nextCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // nextTitle
        this.nextTitle.Name = "nextTitle";
        this.nextTitle.Location = new System.Drawing.Point(23, 21);
        this.nextTitle.Size = new System.Drawing.Size(300, 48);
        this.nextTitle.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.nextTitle.Text = "Saved sample orders";
        this.nextTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.nextTitle.AutoSize = false;
        this.nextTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // nextDescription
        this.nextDescription.Name = "nextDescription";
        this.nextDescription.Location = new System.Drawing.Point(23, 88);
        this.nextDescription.Size = new System.Drawing.Size(296, 146);
        this.nextDescription.ForeColor = System.Drawing.Color.FromArgb(105, 75, 54);
        this.nextDescription.Text = "Saved test orders will be listed here.";
        this.nextDescription.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Regular);
        this.nextDescription.AutoSize = false;
        this.nextDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // backMenu
        this.backMenu.Name = "backMenu";
        this.backMenu.Location = new System.Drawing.Point(22, 251);
        this.backMenu.Size = new System.Drawing.Size(302, 52);
        this.backMenu.BackColor = System.Drawing.Color.FromArgb(79, 98, 62);
        this.backMenu.ForeColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.backMenu.Text = "RETURN TO MENU";
        this.backMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
        this.backMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.backMenu.FlatAppearance.BorderSize = 0;
        this.backMenu.UseVisualStyleBackColor = false;
        this.backMenu.Cursor = System.Windows.Forms.Cursors.Hand;
        this.backMenu.TabIndex = 5;
        this.backMenu.Tag = "CustomerOrder";
        this.backMenu.Click += new System.EventHandler(this.Navigate_Click);

        // summaryAccount
        this.summaryAccount.Name = "summaryAccount";
        this.summaryAccount.Location = new System.Drawing.Point(22, 314);
        this.summaryAccount.Size = new System.Drawing.Size(302, 50);
        this.summaryAccount.BackColor = System.Drawing.Color.FromArgb(255, 253, 249);
        this.summaryAccount.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.summaryAccount.Text = "VIEW SAVED DATA";
        this.summaryAccount.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
        this.summaryAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.summaryAccount.FlatAppearance.BorderSize = 0;
        this.summaryAccount.UseVisualStyleBackColor = false;
        this.summaryAccount.Cursor = System.Windows.Forms.Cursors.Hand;
        this.summaryAccount.TabIndex = 6;
        this.summaryAccount.Tag = "SavedData";
        this.summaryAccount.Click += new System.EventHandler(this.Navigate_Click);

        // placePreview
        this.placePreview.Name = "placePreview";
        this.placePreview.Location = new System.Drawing.Point(40, 579);
        this.placePreview.Size = new System.Drawing.Size(302, 54);
        this.placePreview.BackColor = System.Drawing.Color.FromArgb(223, 180, 81);
        this.placePreview.ForeColor = System.Drawing.Color.FromArgb(55, 73, 44);
        this.placePreview.Text = "PLACE ORDER (PREVIEW)";
        this.placePreview.Font = new System.Drawing.Font("Segoe UI", 10.7F, System.Drawing.FontStyle.Bold);
        this.placePreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.placePreview.FlatAppearance.BorderSize = 0;
        this.placePreview.UseVisualStyleBackColor = false;
        this.placePreview.Cursor = System.Windows.Forms.Cursors.Hand;
        this.placePreview.TabIndex = 7;
        this.placePreview.Click += new System.EventHandler(this.PreviewOnly_Click);

        // placeDisclaimer
        this.placeDisclaimer.Name = "placeDisclaimer";
        this.placeDisclaimer.Location = new System.Drawing.Point(361, 585);
        this.placeDisclaimer.Size = new System.Drawing.Size(704, 42);
        this.placeDisclaimer.ForeColor = System.Drawing.Color.FromArgb(114, 103, 85);
        this.placeDisclaimer.Text = "No customer order is placed through this preview.";
        this.placeDisclaimer.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
        this.placeDisclaimer.AutoSize = false;
        this.placeDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

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
        this.body.Controls.Add(this.summaryCard);
        this.body.Controls.Add(this.nextCard);
        this.body.Controls.Add(this.placePreview);
        this.body.Controls.Add(this.placeDisclaimer);
        this.summaryCard.Controls.Add(this.summaryHeading);
        this.summaryCard.Controls.Add(this.emptyBox);
        this.summaryCard.Controls.Add(this.plannedTotals);
        this.emptyBox.Controls.Add(this.emptyTitle);
        this.emptyBox.Controls.Add(this.emptyDetail);
        this.nextCard.Controls.Add(this.nextTitle);
        this.nextCard.Controls.Add(this.nextDescription);
        this.nextCard.Controls.Add(this.backMenu);
        this.nextCard.Controls.Add(this.summaryAccount);

        // Form
        this.Name = "OrderSummaryForm";
        this.Text = "Olive Branch Bakes — Order Summary";
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
