namespace LicenseHubWF.Views
{
    partial class MessageBoxView
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
            messageBoxIcon = new FontAwesome.Sharp.IconPictureBox();
            messageBoxTitle = new Label();
            btnAccept = new FontAwesome.Sharp.IconButton();
            btnDecline = new FontAwesome.Sharp.IconButton();
            btnOk = new FontAwesome.Sharp.IconButton();
            lblMessage = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)messageBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(88, 40, 65);
            panel1.Controls.Add(messageBoxIcon);
            panel1.Controls.Add(messageBoxTitle);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.FromArgb(249, 158, 76);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 99);
            panel1.TabIndex = 1;
            // 
            // messageBoxIcon
            // 
            messageBoxIcon.BackColor = Color.FromArgb(88, 40, 65);
            messageBoxIcon.ForeColor = Color.FromArgb(249, 158, 76);
            messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
            messageBoxIcon.IconColor = Color.FromArgb(249, 158, 76);
            messageBoxIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            messageBoxIcon.IconSize = 40;
            messageBoxIcon.Location = new Point(155, 12);
            messageBoxIcon.Name = "messageBoxIcon";
            messageBoxIcon.Size = new Size(40, 40);
            messageBoxIcon.TabIndex = 2;
            messageBoxIcon.TabStop = false;
            // 
            // messageBoxTitle
            // 
            messageBoxTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageBoxTitle.Location = new Point(0, 55);
            messageBoxTitle.Name = "messageBoxTitle";
            messageBoxTitle.Size = new Size(350, 24);
            messageBoxTitle.TabIndex = 1;
            messageBoxTitle.Text = "Are you sure ?";
            messageBoxTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(88, 40, 65);
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccept.ForeColor = Color.FromArgb(249, 158, 76);
            btnAccept.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAccept.IconColor = Color.FromArgb(249, 158, 76);
            btnAccept.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAccept.Location = new Point(21, 185);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(125, 40);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Yes";
            btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnDecline
            // 
            btnDecline.BackColor = Color.FromArgb(88, 40, 65);
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDecline.ForeColor = Color.FromArgb(249, 158, 76);
            btnDecline.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDecline.IconColor = Color.FromArgb(249, 158, 76);
            btnDecline.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDecline.Location = new Point(203, 185);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(125, 40);
            btnDecline.TabIndex = 7;
            btnDecline.Text = "No";
            btnDecline.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(88, 40, 65);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOk.ForeColor = Color.FromArgb(249, 158, 76);
            btnOk.IconChar = FontAwesome.Sharp.IconChar.None;
            btnOk.IconColor = Color.FromArgb(249, 158, 76);
            btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOk.Location = new Point(108, 185);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(125, 40);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(0, 112);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(350, 56);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "Notification Message";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MessageBoxView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(204, 42, 73);
            ClientSize = new Size(350, 250);
            Controls.Add(lblMessage);
            Controls.Add(btnOk);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(88, 40, 65);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MessageBoxView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MessageBoxView";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)messageBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label messageBoxTitle;
        private FontAwesome.Sharp.IconButton btnAccept;
        private FontAwesome.Sharp.IconButton btnDecline;
        private FontAwesome.Sharp.IconPictureBox messageBoxIcon;
        private FontAwesome.Sharp.IconButton btnOk;
        private Label lblMessage;
    }
}