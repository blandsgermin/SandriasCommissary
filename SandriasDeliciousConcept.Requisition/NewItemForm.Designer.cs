#nullable disable
namespace SandriasDeliciousConcept.Requisition
{
    partial class NewItemForm
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
            lblName = new Label();
            txtItemName = new TextBox();
            lblUnit = new Label();
            cboUnit = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 23);
            lblName.Name = "lblName";
            lblName.TabIndex = 0;
            lblName.Text = "Item name";
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(110, 20);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(250, 23);
            txtItemName.TabIndex = 1;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(20, 63);
            lblUnit.Name = "lblUnit";
            lblUnit.TabIndex = 2;
            lblUnit.Text = "Unit";
            // 
            // cboUnit
            // 
            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnit.Location = new Point(110, 60);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(150, 23);
            cboUnit.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(190, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 28);
            btnOk.TabIndex = 4;
            btnOk.Text = "Add item";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(280, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 28);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewItemForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(380, 160);
            Controls.Add(lblName);
            Controls.Add(txtItemName);
            Controls.Add(lblUnit);
            Controls.Add(cboUnit);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewItemForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtItemName;
        private Label lblUnit;
        private ComboBox cboUnit;
        private Button btnOk;
        private Button btnCancel;
    }
}