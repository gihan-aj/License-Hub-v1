namespace LicenseHubWF.Views
{
    partial class RequestKeyView
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
            txtRequestKey = new TextBox();
            labelRequestKey = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            lblRequestKeyMessage = new Label();
            btnCopy = new FontAwesome.Sharp.IconButton();
            iconCopied = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconCopied).BeginInit();
            SuspendLayout();
            // 
            // txtRequestKey
            // 
            txtRequestKey.BorderStyle = BorderStyle.FixedSingle;
            txtRequestKey.ForeColor = Color.FromArgb(88, 40, 65);
            txtRequestKey.Location = new Point(40, 75);
            txtRequestKey.Name = "txtRequestKey";
            txtRequestKey.ReadOnly = true;
            txtRequestKey.Size = new Size(600, 25);
            txtRequestKey.TabIndex = 8;
            // 
            // labelRequestKey
            // 
            labelRequestKey.AutoSize = true;
            labelRequestKey.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRequestKey.Location = new Point(40, 45);
            labelRequestKey.Name = "labelRequestKey";
            labelRequestKey.Size = new Size(83, 17);
            labelRequestKey.TabIndex = 7;
            labelRequestKey.Text = "Request Key";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = Color.FromArgb(243, 111, 56);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
            iconPictureBox1.IconColor = Color.FromArgb(243, 111, 56);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.Location = new Point(40, 106);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(32, 32);
            iconPictureBox1.TabIndex = 9;
            iconPictureBox1.TabStop = false;
            // 
            // lblRequestKeyMessage
            // 
            lblRequestKeyMessage.AutoSize = true;
            lblRequestKeyMessage.Location = new Point(78, 111);
            lblRequestKeyMessage.Name = "lblRequestKeyMessage";
            lblRequestKeyMessage.Size = new Size(45, 19);
            lblRequestKeyMessage.TabIndex = 10;
            lblRequestKeyMessage.Text = "label1";
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.FromArgb(88, 40, 65);
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCopy.ForeColor = SystemColors.Window;
            btnCopy.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCopy.IconColor = Color.Black;
            btnCopy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCopy.Location = new Point(360, 400);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(280, 30);
            btnCopy.TabIndex = 11;
            btnCopy.Text = "Copy to Clipboard";
            btnCopy.UseVisualStyleBackColor = false;
            // 
            // iconCopied
            // 
            iconCopied.BackColor = SystemColors.Control;
            iconCopied.ForeColor = Color.FromArgb(243, 111, 56);
            iconCopied.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            iconCopied.IconColor = Color.FromArgb(243, 111, 56);
            iconCopied.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCopied.Location = new Point(322, 403);
            iconCopied.Name = "iconCopied";
            iconCopied.Size = new Size(32, 32);
            iconCopied.TabIndex = 12;
            iconCopied.TabStop = false;
            // 
            // RequestKeyView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 470);
            Controls.Add(iconCopied);
            Controls.Add(btnCopy);
            Controls.Add(lblRequestKeyMessage);
            Controls.Add(iconPictureBox1);
            Controls.Add(txtRequestKey);
            Controls.Add(labelRequestKey);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(243, 111, 56);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RequestKeyView";
            Text = "RequestKeyView";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconCopied).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRequestKey;
        private Label labelRequestKey;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label lblRequestKeyMessage;
        private FontAwesome.Sharp.IconButton btnCopy;
        private FontAwesome.Sharp.IconPictureBox iconCopied;
    }
}