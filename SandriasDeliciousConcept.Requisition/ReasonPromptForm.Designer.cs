#nullable disable
namespace SandriasDeliciousConcept.Requisition
{
    partial class ReasonPromptForm
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
            lblPrompt = new Label();
            txtReason = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(20, 15);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(38, 15);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Reason:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(20, 45);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(360, 23);
            txtReason.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(215, 90);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 28);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(305, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ReasonPromptForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 135);
            Controls.Add(lblPrompt);
            Controls.Add(txtReason);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReasonPromptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reason";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrompt;
        private TextBox txtReason;
        private Button btnOk;
        private Button btnCancel;
    }
}