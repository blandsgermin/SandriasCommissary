#nullable disable
namespace SandriasDeliciousConcept.Requisition
{
    partial class RequisitionListForm
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
            pnlTop = new FlowLayoutPanel();
            lblUser = new Label();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnNew = new Button();
            btnEdit = new Button();
            btnApprove = new Button();
            btnReturn = new Button();
            btnCancel = new Button();
            btnRefresh = new Button();
            dgvRequisitions = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisitions).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.AutoSize = true;
            pnlTop.Controls.Add(lblUser);
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Controls.Add(cboStatus);
            pnlTop.Controls.Add(btnNew);
            pnlTop.Controls.Add(btnEdit);
            pnlTop.Controls.Add(btnApprove);
            pnlTop.Controls.Add(btnReturn);
            pnlTop.Controls.Add(btnCancel);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(8);
            pnlTop.Size = new Size(1000, 50);
            pnlTop.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Margin = new Padding(0, 8, 16, 0);
            lblUser.Name = "lblUser";
            lblUser.TabIndex = 0;
            lblUser.Text = "Logged in as:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Margin = new Padding(0, 8, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(150, 23);
            cboStatus.TabIndex = 2;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 27);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 27);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnApprove
            // 
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(80, 27);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReturn
            // 
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(80, 27);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnCancel
            // 
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 27);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel request";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 27);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvRequisitions
            // 
            dgvRequisitions.AllowUserToAddRows = false;
            dgvRequisitions.AllowUserToDeleteRows = false;
            dgvRequisitions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequisitions.Dock = DockStyle.Fill;
            dgvRequisitions.Location = new Point(0, 50);
            dgvRequisitions.MultiSelect = false;
            dgvRequisitions.Name = "dgvRequisitions";
            dgvRequisitions.ReadOnly = true;
            dgvRequisitions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequisitions.Size = new Size(1000, 470);
            dgvRequisitions.TabIndex = 0;
            // 
            // RequisitionListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 520);
            Controls.Add(dgvRequisitions);
            Controls.Add(pnlTop);
            Name = "RequisitionListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Requisitions";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisitions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlTop;
        private Label lblUser;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnNew;
        private Button btnEdit;
        private Button btnApprove;
        private Button btnReturn;
        private Button btnCancel;
        private Button btnRefresh;
        private DataGridView dgvRequisitions;
    }
}