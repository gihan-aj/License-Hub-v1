namespace LicenseHubWF.Views
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnClose = new FontAwesome.Sharp.IconButton();
            btnReset = new FontAwesome.Sharp.IconButton();
            btnLogin = new FontAwesome.Sharp.IconButton();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(88, 40, 65);
            panel1.Controls.Add(iconPictureBox1);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 200);
            panel1.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(88, 40, 65);
            iconPictureBox1.ForeColor = Color.FromArgb(249, 158, 76);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconPictureBox1.IconColor = Color.FromArgb(249, 158, 76);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 70;
            iconPictureBox1.Location = new Point(115, 80);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(70, 70);
            iconPictureBox1.TabIndex = 2;
            iconPictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(88, 40, 65);
            btnClose.FlatAppearance.BorderSize = 2;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.IconChar = FontAwesome.Sharp.IconChar.None;
            btnClose.IconColor = Color.Black;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(258, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.Dock = DockStyle.Bottom;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.IconChar = FontAwesome.Sharp.IconChar.None;
            btnReset.IconColor = Color.FromArgb(249, 158, 76);
            btnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReset.IconSize = 30;
            btnReset.ImageAlign = ContentAlignment.MiddleLeft;
            btnReset.Location = new Point(0, 400);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(300, 60);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(88, 40, 65);
            btnLogin.Dock = DockStyle.Bottom;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.IconChar = FontAwesome.Sharp.IconChar.None;
            btnLogin.IconColor = Color.FromArgb(249, 158, 76);
            btnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogin.IconSize = 30;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(0, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 60);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(30, 230);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(240, 25);
            txtEmail.TabIndex = 4;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(30, 285);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(240, 25);
            txtPassword.TabIndex = 5;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(300, 460);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(btnLogin);
            Controls.Add(btnReset);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(249, 158, 76);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnReset;
        private FontAwesome.Sharp.IconButton btnLogin;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBox txtEmail;
        private TextBox txtPassword;
    }
}