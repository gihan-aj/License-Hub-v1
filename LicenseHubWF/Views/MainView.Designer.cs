namespace LicenseHubWF.Views
{
    partial class MainView
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
            panelSideBar = new Panel();
            btnRequestLicense = new FontAwesome.Sharp.IconButton();
            btnViewLicense = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            panelTopBar = new Panel();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelChildFormWindow = new Panel();
            panelSideBar.SuspendLayout();
            panelTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(88, 40, 65);
            panelSideBar.Controls.Add(btnRequestLicense);
            panelSideBar.Controls.Add(btnViewLicense);
            panelSideBar.Controls.Add(btnHome);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.ForeColor = Color.FromArgb(249, 158, 76);
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(220, 600);
            panelSideBar.TabIndex = 0;
            // 
            // btnRequestLicense
            // 
            btnRequestLicense.FlatAppearance.BorderSize = 0;
            btnRequestLicense.FlatStyle = FlatStyle.Flat;
            btnRequestLicense.Font = new Font("Segoe UI", 12F);
            btnRequestLicense.IconChar = FontAwesome.Sharp.IconChar.Upload;
            btnRequestLicense.IconColor = Color.FromArgb(249, 158, 76);
            btnRequestLicense.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRequestLicense.IconSize = 30;
            btnRequestLicense.ImageAlign = ContentAlignment.MiddleLeft;
            btnRequestLicense.Location = new Point(0, 190);
            btnRequestLicense.Name = "btnRequestLicense";
            btnRequestLicense.Padding = new Padding(10, 0, 0, 0);
            btnRequestLicense.Size = new Size(220, 60);
            btnRequestLicense.TabIndex = 2;
            btnRequestLicense.Text = "Request License";
            btnRequestLicense.TextAlign = ContentAlignment.MiddleLeft;
            btnRequestLicense.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRequestLicense.UseVisualStyleBackColor = true;
            // 
            // btnViewLicense
            // 
            btnViewLicense.FlatAppearance.BorderSize = 0;
            btnViewLicense.FlatStyle = FlatStyle.Flat;
            btnViewLicense.Font = new Font("Segoe UI", 12F);
            btnViewLicense.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            btnViewLicense.IconColor = Color.FromArgb(249, 158, 76);
            btnViewLicense.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewLicense.IconSize = 30;
            btnViewLicense.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewLicense.Location = new Point(0, 130);
            btnViewLicense.Name = "btnViewLicense";
            btnViewLicense.Padding = new Padding(10, 0, 0, 0);
            btnViewLicense.Size = new Size(220, 60);
            btnViewLicense.TabIndex = 1;
            btnViewLicense.Text = "View License";
            btnViewLicense.TextAlign = ContentAlignment.MiddleLeft;
            btnViewLicense.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnViewLicense.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(88, 40, 65);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.IconChar = FontAwesome.Sharp.IconChar.Building;
            btnHome.IconColor = Color.FromArgb(249, 158, 76);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 50;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(0, 0, 0, 15);
            btnHome.Size = new Size(220, 130);
            btnHome.TabIndex = 0;
            btnHome.Text = "DSP Keys";
            btnHome.TextAlign = ContentAlignment.BottomCenter;
            btnHome.UseVisualStyleBackColor = false;
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(204, 42, 73);
            panelTopBar.Controls.Add(btnMinimize);
            panelTopBar.Controls.Add(btnClose);
            panelTopBar.ForeColor = Color.FromArgb(243, 111, 56);
            panelTopBar.Location = new Point(220, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(680, 130);
            panelTopBar.TabIndex = 1;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(88, 40, 65);
            btnMinimize.FlatAppearance.BorderSize = 2;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMinimize.IconColor = Color.Black;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.Location = new Point(599, 15);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
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
            btnClose.Location = new Point(635, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // panelChildFormWindow
            // 
            panelChildFormWindow.Location = new Point(220, 130);
            panelChildFormWindow.Name = "panelChildFormWindow";
            panelChildFormWindow.Size = new Size(680, 468);
            panelChildFormWindow.TabIndex = 2;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(panelChildFormWindow);
            Controls.Add(panelTopBar);
            Controls.Add(panelSideBar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainView";
            panelSideBar.ResumeLayout(false);
            panelTopBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideBar;
        private Panel panelTopBar;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnViewLicense;
        private FontAwesome.Sharp.IconButton btnRequestLicense;
        private Panel panelChildFormWindow;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMinimize;
    }
}