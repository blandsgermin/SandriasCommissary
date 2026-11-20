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
            lblOrderType = new Label();
            cboOrderType = new ComboBox();
            lblCustomer = new Label();
            txtCustomer = new TextBox();
            lblEventDate = new Label();
            dtpEventDate = new DateTimePicker();
            lblVenue = new Label();
            txtVenue = new TextBox();
            lblPax = new Label();
            nudPax = new NumericUpDown();
            lblPaxNote = new Label();
            lblPurpose = new Label();
            txtPurpose = new TextBox();
            lblRequired = new Label();
            dtpRequired = new DateTimePicker();
            lblDishes = new Label();
            lblPackageNote = new Label();
            cboDish = new ComboBox();
            btnAddDish = new Button();
            txtCustomDish = new TextBox();
            btnAddCustom = new Button();
            dgvDishes = new DataGridView();
            colDish = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colPacks = new DataGridViewTextBoxColumn();
            btnRemoveDish = new Button();
            lblItems = new Label();
            btnNewItem = new Button();
            dgvItems = new DataGridView();
            colItem = new DataGridViewComboBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colNotes = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDishes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // lblOrderType
            // 
            lblOrderType.AutoSize = true;
            lblOrderType.Location = new Point(20, 23);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.TabIndex = 0;
            lblOrderType.Text = "Order type";
            // 
            // cboOrderType
            // 
            cboOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrderType.Location = new Point(180, 20);
            cboOrderType.Name = "cboOrderType";
            cboOrderType.Size = new Size(200, 23);
            cboOrderType.TabIndex = 1;
            cboOrderType.SelectedIndexChanged += cboOrderType_SelectedIndexChanged;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(20, 58);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Customer name";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(180, 55);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(480, 23);
            txtCustomer.TabIndex = 3;
            // 
            // lblEventDate
            // 
            lblEventDate.AutoSize = true;
            lblEventDate.Location = new Point(20, 93);
            lblEventDate.Name = "lblEventDate";
            lblEventDate.TabIndex = 4;
            lblEventDate.Text = "Event date";
            // 
            // dtpEventDate
            // 
            dtpEventDate.Format = DateTimePickerFormat.Short;
            dtpEventDate.Location = new Point(180, 90);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(200, 23);
            dtpEventDate.TabIndex = 5;
            // 
            // lblVenue
            // 
            lblVenue.AutoSize = true;
            lblVenue.Location = new Point(20, 128);
            lblVenue.Name = "lblVenue";
            lblVenue.TabIndex = 6;
            lblVenue.Text = "Venue";
            // 
            // txtVenue
            // 
            txtVenue.Location = new Point(180, 125);
            txtVenue.Name = "txtVenue";
            txtVenue.Size = new Size(480, 23);
            txtVenue.TabIndex = 7;
            // 
            // lblPax
            // 
            lblPax.AutoSize = true;
            lblPax.Location = new Point(20, 163);
            lblPax.Name = "lblPax";
            lblPax.TabIndex = 8;
            lblPax.Text = "Number of pax";
            // 
            // nudPax
            // 
            nudPax.Location = new Point(180, 160);
            nudPax.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPax.Name = "nudPax";
            nudPax.Size = new Size(120, 23);
            nudPax.TabIndex = 9;
            // 
            // lblPaxNote
            // 
            lblPaxNote.AutoSize = true;
            lblPaxNote.ForeColor = SystemColors.GrayText;
            lblPaxNote.Location = new Point(310, 163);
            lblPaxNote.Name = "lblPaxNote";
            lblPaxNote.TabIndex = 10;
            lblPaxNote.Text = "Number of guests";
            // 
            // lblPurpose
            // 
            lblPurpose.AutoSize = true;
            lblPurpose.Location = new Point(20, 198);
            lblPurpose.Name = "lblPurpose";
            lblPurpose.TabIndex = 11;
            lblPurpose.Text = "Purpose";
            // 
            // txtPurpose
            // 
            txtPurpose.Location = new Point(180, 195);
            txtPurpose.Name = "txtPurpose";
            txtPurpose.Size = new Size(480, 23);
            txtPurpose.TabIndex = 12;
            // 
            // lblRequired
            // 
            lblRequired.AutoSize = true;
            lblRequired.Location = new Point(20, 233);
            lblRequired.Name = "lblRequired";
            lblRequired.TabIndex = 13;
            lblRequired.Text = "Required date";
            // 
            // dtpRequired
            // 
            dtpRequired.Format = DateTimePickerFormat.Short;
            dtpRequired.Location = new Point(180, 230);
            dtpRequired.Name = "dtpRequired";
            dtpRequired.Size = new Size(200, 23);
            dtpRequired.TabIndex = 14;
            // 
            // lblDishes
            // 
            lblDishes.AutoSize = true;
            lblDishes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDishes.Location = new Point(20, 270);
            lblDishes.Name = "lblDishes";
            lblDishes.TabIndex = 15;
            lblDishes.Text = "Main dishes";
            // 
            // lblPackageNote
            // 
            lblPackageNote.ForeColor = SystemColors.GrayText;
            lblPackageNote.Location = new Point(20, 292);
            lblPackageNote.Name = "lblPackageNote";
            lblPackageNote.Size = new Size(660, 34);
            lblPackageNote.TabIndex = 16;
            // 
            // cboDish
            // 
            cboDish.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDish.Location = new Point(20, 333);
            cboDish.Name = "cboDish";
            cboDish.Size = new Size(250, 23);
            cboDish.TabIndex = 17;
            // 
            // btnAddDish
            // 
            btnAddDish.Location = new Point(275, 331);
            btnAddDish.Name = "btnAddDish";
            btnAddDish.Size = new Size(80, 27);
            btnAddDish.TabIndex = 18;
            btnAddDish.Text = "Add dish";
            btnAddDish.UseVisualStyleBackColor = true;
            btnAddDish.Click += btnAddDish_Click;
            // 
            // txtCustomDish
            // 
            txtCustomDish.Location = new Point(365, 333);
            txtCustomDish.Name = "txtCustomDish";
            txtCustomDish.PlaceholderText = "Custom dish name";
            txtCustomDish.Size = new Size(205, 23);
            txtCustomDish.TabIndex = 19;
            // 
            // btnAddCustom
            // 
            btnAddCustom.Location = new Point(575, 331);
            btnAddCustom.Name = "btnAddCustom";
            btnAddCustom.Size = new Size(105, 27);
            btnAddCustom.TabIndex = 20;
            btnAddCustom.Text = "Add custom";
            btnAddCustom.UseVisualStyleBackColor = true;
            btnAddCustom.Click += btnAddCustom_Click;
            // 
            // dgvDishes
            // 
            dgvDishes.AllowUserToAddRows = false;
            dgvDishes.AllowUserToDeleteRows = false;
            dgvDishes.Columns.AddRange(new DataGridViewColumn[] { colDish, colCategory, colPacks });
            dgvDishes.Location = new Point(20, 368);
            dgvDishes.MultiSelect = false;
            dgvDishes.Name = "dgvDishes";
            dgvDishes.RowHeadersVisible = false;
            dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDishes.Size = new Size(660, 120);
            dgvDishes.TabIndex = 21;
            dgvDishes.CellValueChanged += dgvDishes_CellValueChanged;
            // 
            // colDish
            // 
            colDish.HeaderText = "Dish";
            colDish.Name = "colDish";
            colDish.ReadOnly = true;
            colDish.Width = 300;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            colCategory.Width = 180;
            // 
            // colPacks
            // 
            colPacks.HeaderText = "Boxes";
            colPacks.Name = "colPacks";
            colPacks.Width = 120;
            // 
            // btnRemoveDish
            // 
            btnRemoveDish.Location = new Point(20, 493);
            btnRemoveDish.Name = "btnRemoveDish";
            btnRemoveDish.Size = new Size(160, 27);
            btnRemoveDish.TabIndex = 22;
            btnRemoveDish.Text = "Remove selected dish";
            btnRemoveDish.UseVisualStyleBackColor = true;
            btnRemoveDish.Click += btnRemoveDish_Click;
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItems.Location = new Point(20, 535);
            lblItems.Name = "lblItems";
            lblItems.TabIndex = 23;
            lblItems.Text = "Ingredients and supplies needed";
            // 
            // btnNewItem
            // 
            btnNewItem.Location = new Point(540, 529);
            btnNewItem.Name = "btnNewItem";
            btnNewItem.Size = new Size(140, 27);
            btnNewItem.TabIndex = 24;
            btnNewItem.Text = "+ New item";
            btnNewItem.UseVisualStyleBackColor = true;
            btnNewItem.Click += btnNewItem_Click;
            // 
            // dgvItems
            // 
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { colItem, colUnit, colQuantity, colNotes });
            dgvItems.Location = new Point(20, 560);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(660, 190);
            dgvItems.TabIndex = 25;
            dgvItems.CellValueChanged += dgvItems_CellValueChanged;
            dgvItems.CurrentCellDirtyStateChanged += dgvItems_CurrentCellDirtyStateChanged;
            // 
            // colItem
            // 
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            colItem.Width = 220;
            // 
            // colUnit
            // 
            colUnit.HeaderText = "Unit";
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            colUnit.Width = 70;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 100;
            // 
            // colNotes
            // 
            colNotes.HeaderText = "For dish / notes";
            colNotes.Name = "colNotes";
            colNotes.Width = 230;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(500, 765);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 30);
            btnSave.TabIndex = 26;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(595, 765);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RequisitionEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(700, 815);
            Controls.Add(lblOrderType);
            Controls.Add(cboOrderType);
            Controls.Add(lblCustomer);
            Controls.Add(txtCustomer);
            Controls.Add(lblEventDate);
            Controls.Add(dtpEventDate);
            Controls.Add(lblVenue);
            Controls.Add(txtVenue);
            Controls.Add(lblPax);
            Controls.Add(nudPax);
            Controls.Add(lblPaxNote);
            Controls.Add(lblPurpose);
            Controls.Add(txtPurpose);
            Controls.Add(lblRequired);
            Controls.Add(dtpRequired);
            Controls.Add(lblDishes);
            Controls.Add(lblPackageNote);
            Controls.Add(cboDish);
            Controls.Add(btnAddDish);
            Controls.Add(txtCustomDish);
            Controls.Add(btnAddCustom);
            Controls.Add(dgvDishes);
            Controls.Add(btnRemoveDish);
            Controls.Add(lblItems);
            Controls.Add(btnNewItem);
            Controls.Add(dgvItems);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "RequisitionEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Requisition";
            ((System.ComponentModel.ISupportInitialize)nudPax).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDishes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderType;
        private ComboBox cboOrderType;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Label lblEventDate;
        private DateTimePicker dtpEventDate;
        private Label lblVenue;
        private TextBox txtVenue;
        private Label lblPax;
        private NumericUpDown nudPax;
        private Label lblPaxNote;
        private Label lblPurpose;
        private TextBox txtPurpose;
        private Label lblRequired;
        private DateTimePicker dtpRequired;
        private Label lblDishes;
        private Label lblPackageNote;
        private ComboBox cboDish;
        private Button btnAddDish;
        private TextBox txtCustomDish;
        private Button btnAddCustom;
        private DataGridView dgvDishes;
        private DataGridViewTextBoxColumn colDish;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colPacks;
        private Button btnRemoveDish;
        private Label lblItems;
        private Button btnNewItem;
        private DataGridView dgvItems;
        private DataGridViewComboBoxColumn colItem;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colNotes;
        private Button btnSave;
        private Button btnCancel;
    }
}