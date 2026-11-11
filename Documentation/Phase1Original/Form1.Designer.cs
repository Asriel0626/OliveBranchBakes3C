namespace OliveBranchBakes
{
    partial class ProjectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonNewOrder = new Button();
            buttonViewOrders = new Button();
            buttonManageOrder = new Button();
            buttonProjectinformation = new Button();
            SuspendLayout();
            // 
            // buttonNewOrder
            // 
            buttonNewOrder.Location = new Point(12, 12);
            buttonNewOrder.Name = "buttonNewOrder";
            buttonNewOrder.Size = new Size(99, 36);
            buttonNewOrder.TabIndex = 0;
            buttonNewOrder.Text = "New Order";
            buttonNewOrder.UseVisualStyleBackColor = true;
            // 
            // buttonViewOrders
            // 
            buttonViewOrders.Location = new Point(117, 12);
            buttonViewOrders.Name = "buttonViewOrders";
            buttonViewOrders.Size = new Size(99, 36);
            buttonViewOrders.TabIndex = 1;
            buttonViewOrders.Text = "View Orders";
            buttonViewOrders.UseVisualStyleBackColor = true;
            // 
            // buttonManageOrder
            // 
            buttonManageOrder.Location = new Point(12, 54);
            buttonManageOrder.Name = "buttonManageOrder";
            buttonManageOrder.Size = new Size(204, 36);
            buttonManageOrder.TabIndex = 2;
            buttonManageOrder.Text = "Manage Orders";
            buttonManageOrder.UseVisualStyleBackColor = true;
            // 
            // buttonProjectinformation
            // 
            buttonProjectinformation.Location = new Point(12, 96);
            buttonProjectinformation.Name = "buttonProjectinformation";
            buttonProjectinformation.Size = new Size(204, 36);
            buttonProjectinformation.TabIndex = 3;
            buttonProjectinformation.Text = "Project Information";
            buttonProjectinformation.UseVisualStyleBackColor = true;
            buttonProjectinformation.Click += buttonProjectinformation_Click;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonProjectinformation);
            Controls.Add(buttonManageOrder);
            Controls.Add(buttonViewOrders);
            Controls.Add(buttonNewOrder);
            Name = "ProjectForm";
            Text = "Olive Branch Bake";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonNewOrder;
        private Button buttonViewOrders;
        private Button buttonManageOrder;
        private Button buttonProjectinformation;
    }
}
