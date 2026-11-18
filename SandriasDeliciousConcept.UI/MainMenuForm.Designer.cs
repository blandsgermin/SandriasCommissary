#nullable disable
namespace SandriasDeliciousConcept.UI
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblRole = new Label();
            btnRequisition = new Button();
            btnInventory = new Button();
            btnPurchasing = new Button();
            btnDelivery = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 55);
            lblRole.Name = "lblRole";
            lblRole.TabIndex = 1;
            lblRole.Text = "Role";
            // 
            // btnRequisition
            // 
            btnRequisition.Location = new Point(20, 90);
            btnRequisition.Name = "btnRequisition";
            btnRequisition.Size = new Size(380, 48);
            btnRequisition.TabIndex = 2;
            btnRequisition.Text = "Requisition";
            btnRequisition.UseVisualStyleBackColor = true;
            btnRequisition.Click += btnRequisition_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(20, 148);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(380, 48);
            btnInventory.TabIndex = 3;
            btnInventory.Text = "Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnPurchasing
            // 
            btnPurchasing.Location = new Point(20, 206);
            btnPurchasing.Name = "btnPurchasing";
            btnPurchasing.Size = new Size(380, 48);
            btnPurchasing.TabIndex = 4;
            btnPurchasing.Text = "Purchasing";
            btnPurchasing.UseVisualStyleBackColor = true;
            btnPurchasing.Click += btnPurchasing_Click;
            // 
            // btnDelivery
            // 
            btnDelivery.Location = new Point(20, 264);
            btnDelivery.Name = "btnDelivery";
            btnDelivery.Size = new Size(380, 48);
            btnDelivery.TabIndex = 5;
            btnDelivery.Text = "Delivery";
            btnDelivery.UseVisualStyleBackColor = true;
            btnDelivery.Click += btnDelivery_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(20, 335);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(380, 32);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 385);
            Controls.Add(lblWelcome);
            Controls.Add(lblRole);
            Controls.Add(btnRequisition);
            Controls.Add(btnInventory);
            Controls.Add(btnPurchasing);
            Controls.Add(btnDelivery);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblRole;
        private Button btnRequisition;
        private Button btnInventory;
        private Button btnPurchasing;
        private Button btnDelivery;
        private Button btnLogout;
    }
}