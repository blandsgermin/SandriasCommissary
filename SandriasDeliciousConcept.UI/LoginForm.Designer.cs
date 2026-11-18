#nullable disable
namespace SandriasDeliciousConcept.UI
{
    partial class LoginForm
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
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblError = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sandria's Commissary System";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 75);
            lblUsername.Name = "lblUsername";
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 98);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 135);
            lblPassword.Name = "lblPassword";
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 158);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(20, 192);
            lblError.Name = "lblError";
            lblError.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(180, 225);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(85, 30);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.DialogResult = DialogResult.Cancel;
            btnExit.Location = new Point(275, 225);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 30);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(380, 280);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblError;
        private Button btnLogin;
        private Button btnExit;
    }
}