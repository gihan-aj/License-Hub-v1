namespace LicenseHubWF.Views
{
    partial class ConfirmationView
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
            label1 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnAccept = new FontAwesome.Sharp.IconButton();
            btnDecline = new FontAwesome.Sharp.IconButton();
            txtWarningMessage = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(88, 40, 65);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(iconPictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.FromArgb(249, 158, 76);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 113);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(117, 76);
            label1.Name = "label1";
            label1.Size = new Size(116, 21);
            label1.TabIndex = 1;
            label1.Text = "Are you sure ?";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(88, 40, 65);
            iconPictureBox1.ForeColor = Color.FromArgb(249, 158, 76);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
            iconPictureBox1.IconColor = Color.FromArgb(249, 158, 76);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 40;
            iconPictureBox1.Location = new Point(155, 25);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(40, 40);
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
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
            btnAccept.Location = new Point(33, 177);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(125, 40);
            btnAccept.TabIndex = 2;
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
            btnDecline.Location = new Point(191, 177);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(125, 40);
            btnDecline.TabIndex = 3;
            btnDecline.Text = "No";
            btnDecline.UseVisualStyleBackColor = false;
            // 
            // txtWarningMessage
            // 
            txtWarningMessage.BackColor = Color.FromArgb(204, 42, 73);
            txtWarningMessage.BorderStyle = BorderStyle.None;
            txtWarningMessage.ForeColor = Color.FromArgb(88, 40, 65);
            txtWarningMessage.Location = new Point(33, 130);
            txtWarningMessage.Multiline = true;
            txtWarningMessage.Name = "txtWarningMessage";
            txtWarningMessage.ReadOnly = true;
            txtWarningMessage.Size = new Size(283, 31);
            txtWarningMessage.TabIndex = 4;
            txtWarningMessage.TextAlign = HorizontalAlignment.Center;
            // 
            // ConfirmationView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(204, 42, 73);
            ClientSize = new Size(350, 250);
            Controls.Add(txtWarningMessage);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(88, 40, 65);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConfirmationView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConfirmationView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnAccept;
        private FontAwesome.Sharp.IconButton btnDecline;
        private TextBox txtWarningMessage;
    }
}