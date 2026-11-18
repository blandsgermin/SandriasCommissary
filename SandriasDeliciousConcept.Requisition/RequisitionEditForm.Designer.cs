#nullable disable
namespace SandriasDeliciousConcept.Requisition
{
    partial class RequisitionEditForm
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
            lblCustomer = new Label();
            txtCustomer = new TextBox();
            lblEventDate = new Label();
            dtpEventDate = new DateTimePicker();
            lblVenue = new Label();
            txtVenue = new TextBox();
            lblPax = new Label();
            nudPax = new NumericUpDown();
            lblMenu = new Label();
            cboMenu = new ComboBox();
            lblPurpose = new Label();
            txtPurpose = new TextBox();
            lblRequired = new Label();
            dtpRequired = new DateTimePicker();
            lblItems = new Label();
            dgvItems = new DataGridView();
            colItem = new DataGridViewComboBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(20, 23);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer name";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(180, 20);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(400, 23);
            txtCustomer.TabIndex = 1;
            // 
            // lblEventDate
            // 
            lblEventDate.AutoSize = true;
            lblEventDate.Location = new Point(20, 58);
            lblEventDate.Name = "lblEventDate";
            lblEventDate.TabIndex = 2;
            lblEventDate.Text = "Event date";
            // 
            // dtpEventDate
            // 
            dtpEventDate.Format = DateTimePickerFormat.Short;
            dtpEventDate.Location = new Point(180, 55);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(200, 23);
            dtpEventDate.TabIndex = 3;
            // 
            // lblVenue
            // 
            lblVenue.AutoSize = true;
            lblVenue.Location = new Point(20, 93);
            lblVenue.Name = "lblVenue";
            lblVenue.TabIndex = 4;
            lblVenue.Text = "Venue";
            // 
            // txtVenue
            // 
            txtVenue.Location = new Point(180, 90);
            txtVenue.Name = "txtVenue";
            txtVenue.Size = new Size(400, 23);
            txtVenue.TabIndex = 5;
            // 
            // lblPax
            // 
            lblPax.AutoSize = true;
            lblPax.Location = new Point(20, 128);
            lblPax.Name = "lblPax";
            lblPax.TabIndex = 6;
            lblPax.Text = "Number of pax";
            // 
            // nudPax
            // 
            nudPax.Location = new Point(180, 125);
            nudPax.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPax.Name = "nudPax";
            nudPax.Size = new Size(120, 23);
            nudPax.TabIndex = 7;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Location = new Point(20, 163);
            lblMenu.Name = "lblMenu";
            lblMenu.TabIndex = 8;
            lblMenu.Text = "Menu (main course)";
            // 
            // cboMenu
            // 
            cboMenu.Items.AddRange(new object[] { "Pork", "Beef", "Chicken", "Pancit", "Vegetables" });
            cboMenu.Location = new Point(180, 160);
            cboMenu.Name = "cboMenu";
            cboMenu.Size = new Size(400, 23);
            cboMenu.TabIndex = 9;
            // 
            // lblPurpose
            // 
            lblPurpose.AutoSize = true;
            lblPurpose.Location = new Point(20, 198);
            lblPurpose.Name = "lblPurpose";
            lblPurpose.TabIndex = 10;
            lblPurpose.Text = "Purpose";
            // 
            // txtPurpose
            // 
            txtPurpose.Location = new Point(180, 195);
            txtPurpose.Name = "txtPurpose";
            txtPurpose.Size = new Size(400, 23);
            txtPurpose.TabIndex = 11;
            // 
            // lblRequired
            // 
            lblRequired.AutoSize = true;
            lblRequired.Location = new Point(20, 233);
            lblRequired.Name = "lblRequired";
            lblRequired.TabIndex = 12;
            lblRequired.Text = "Required date";
            // 
            // dtpRequired
            // 
            dtpRequired.Format = DateTimePickerFormat.Short;
            dtpRequired.Location = new Point(180, 230);
            dtpRequired.Name = "dtpRequired";
            dtpRequired.Size = new Size(200, 23);
            dtpRequired.TabIndex = 13;
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Location = new Point(20, 270);
            lblItems.Name = "lblItems";
            lblItems.TabIndex = 14;
            lblItems.Text = "Items needed";
            // 
            // dgvItems
            // 
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { colItem, colUnit, colQuantity });
            dgvItems.Location = new Point(20, 295);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(560, 240);
            dgvItems.TabIndex = 15;
            dgvItems.CellValueChanged += dgvItems_CellValueChanged;
            dgvItems.CurrentCellDirtyStateChanged += dgvItems_CurrentCellDirtyStateChanged;
            // 
            // colItem
            // 
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.Width = 260;
            // 
            // colUnit
            // 
            colUnit.HeaderText = "Unit";
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            colUnit.Width = 80;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 120;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(400, 552);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 30);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(495, 552);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RequisitionEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(600, 595);
            Controls.Add(lblCustomer);
            Controls.Add(txtCustomer);
            Controls.Add(lblEventDate);
            Controls.Add(dtpEventDate);
            Controls.Add(lblVenue);
            Controls.Add(txtVenue);
            Controls.Add(lblPax);
            Controls.Add(nudPax);
            Controls.Add(lblMenu);
            Controls.Add(cboMenu);
            Controls.Add(lblPurpose);
            Controls.Add(txtPurpose);
            Controls.Add(lblRequired);
            Controls.Add(dtpRequired);
            Controls.Add(lblItems);
            Controls.Add(dgvItems);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "RequisitionEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Requisition";
            ((System.ComponentModel.ISupportInitialize)nudPax).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private TextBox txtCustomer;
        private Label lblEventDate;
        private DateTimePicker dtpEventDate;
        private Label lblVenue;
        private TextBox txtVenue;
        private Label lblPax;
        private NumericUpDown nudPax;
        private Label lblMenu;
        private ComboBox cboMenu;
        private Label lblPurpose;
        private TextBox txtPurpose;
        private Label lblRequired;
        private DateTimePicker dtpRequired;
        private Label lblItems;
        private DataGridView dgvItems;
        private DataGridViewComboBoxColumn colItem;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colQuantity;
        private Button btnSave;
        private Button btnCancel;
    }
}