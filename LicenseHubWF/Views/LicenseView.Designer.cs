namespace LicenseHubWF.Views
{
    partial class LicenseView
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
            lblLicenseId = new Label();
            lblPackageList = new Label();
            lblPcName = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblCustomer = new Label();
            txtLicenseId = new TextBox();
            txtCustomer = new TextBox();
            txtStartDate = new TextBox();
            txtEndDate = new TextBox();
            txtPcName = new TextBox();
            txtPackageList = new TextBox();
            btnBrowse = new FontAwesome.Sharp.IconButton();
            btnValidate = new FontAwesome.Sharp.IconButton();
            lblFilePath = new Label();
            SuspendLayout();
            // 
            // lblLicenseId
            // 
            lblLicenseId.AutoSize = true;
            lblLicenseId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseId.Location = new Point(38, 40);
            lblLicenseId.Name = "lblLicenseId";
            lblLicenseId.Size = new Size(71, 17);
            lblLicenseId.TabIndex = 0;
            lblLicenseId.Text = "License ID";
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPackageList.Location = new Point(358, 130);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(64, 17);
            lblPackageList.TabIndex = 2;
            lblPackageList.Text = "Packages";
            // 
            // lblPcName
            // 
            lblPcName.AutoSize = true;
            lblPcName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPcName.Location = new Point(38, 220);
            lblPcName.Name = "lblPcName";
            lblPcName.Size = new Size(64, 17);
            lblPcName.TabIndex = 3;
            lblPcName.Text = "PC Name";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDate.Location = new Point(192, 130);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(64, 17);
            lblEndDate.TabIndex = 4;
            lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartDate.Location = new Point(38, 130);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(70, 17);
            lblStartDate.TabIndex = 5;
            lblStartDate.Text = "Start Date";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(358, 40);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(67, 17);
            lblCustomer.TabIndex = 6;
            lblCustomer.Text = "Customer";
            // 
            // txtLicenseId
            // 
            txtLicenseId.BorderStyle = BorderStyle.FixedSingle;
            txtLicenseId.ForeColor = Color.FromArgb(88, 40, 65);
            txtLicenseId.Location = new Point(38, 70);
            txtLicenseId.Name = "txtLicenseId";
            txtLicenseId.ReadOnly = true;
            txtLicenseId.Size = new Size(280, 25);
            txtLicenseId.TabIndex = 7;
            // 
            // txtCustomer
            // 
            txtCustomer.BorderStyle = BorderStyle.FixedSingle;
            txtCustomer.ForeColor = Color.FromArgb(88, 40, 65);
            txtCustomer.Location = new Point(358, 70);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(280, 25);
            txtCustomer.TabIndex = 8;
            // 
            // txtStartDate
            // 
            txtStartDate.BorderStyle = BorderStyle.FixedSingle;
            txtStartDate.ForeColor = Color.FromArgb(88, 40, 65);
            txtStartDate.Location = new Point(38, 160);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ReadOnly = true;
            txtStartDate.Size = new Size(126, 25);
            txtStartDate.TabIndex = 9;
            // 
            // txtEndDate
            // 
            txtEndDate.BorderStyle = BorderStyle.FixedSingle;
            txtEndDate.ForeColor = Color.FromArgb(88, 40, 65);
            txtEndDate.Location = new Point(192, 160);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ReadOnly = true;
            txtEndDate.Size = new Size(126, 25);
            txtEndDate.TabIndex = 10;
            // 
            // txtPcName
            // 
            txtPcName.BorderStyle = BorderStyle.FixedSingle;
            txtPcName.ForeColor = Color.FromArgb(88, 40, 65);
            txtPcName.Location = new Point(38, 250);
            txtPcName.Name = "txtPcName";
            txtPcName.ReadOnly = true;
            txtPcName.Size = new Size(280, 25);
            txtPcName.TabIndex = 11;
            // 
            // txtPackageList
            // 
            txtPackageList.BorderStyle = BorderStyle.FixedSingle;
            txtPackageList.ForeColor = Color.FromArgb(88, 40, 65);
            txtPackageList.Location = new Point(358, 162);
            txtPackageList.Multiline = true;
            txtPackageList.Name = "txtPackageList";
            txtPackageList.ReadOnly = true;
            txtPackageList.Size = new Size(280, 181);
            txtPackageList.TabIndex = 12;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(88, 40, 65);
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = SystemColors.Window;
            btnBrowse.IconChar = FontAwesome.Sharp.IconChar.None;
            btnBrowse.IconColor = Color.Black;
            btnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBrowse.Location = new Point(38, 400);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(280, 30);
            btnBrowse.TabIndex = 13;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // btnValidate
            // 
            btnValidate.BackColor = Color.FromArgb(88, 40, 65);
            btnValidate.FlatAppearance.BorderSize = 0;
            btnValidate.FlatStyle = FlatStyle.Flat;
            btnValidate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnValidate.ForeColor = SystemColors.Window;
            btnValidate.IconChar = FontAwesome.Sharp.IconChar.None;
            btnValidate.IconColor = Color.Black;
            btnValidate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnValidate.Location = new Point(358, 400);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(280, 30);
            btnValidate.TabIndex = 14;
            btnValidate.Text = "Validate";
            btnValidate.UseVisualStyleBackColor = false;
            // 
            // lblFilePath
            // 
            lblFilePath.Location = new Point(38, 370);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(601, 20);
            lblFilePath.TabIndex = 15;
            lblFilePath.Text = "File Path";
            // 
            // LicenseView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 470);
            Controls.Add(lblFilePath);
            Controls.Add(btnValidate);
            Controls.Add(btnBrowse);
            Controls.Add(txtPackageList);
            Controls.Add(txtPcName);
            Controls.Add(txtEndDate);
            Controls.Add(txtStartDate);
            Controls.Add(txtCustomer);
            Controls.Add(txtLicenseId);
            Controls.Add(lblCustomer);
            Controls.Add(lblStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(lblPcName);
            Controls.Add(lblPackageList);
            Controls.Add(lblLicenseId);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(243, 111, 56);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LicenseView";
            Text = "LicenseView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLicenseId;
        private Label lblPackageList;
        private Label lblPcName;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblCustomer;
        private TextBox txtLicenseId;
        private TextBox txtCustomer;
        private TextBox txtStartDate;
        private TextBox txtEndDate;
        private TextBox txtPcName;
        private TextBox txtPackageList;
        private FontAwesome.Sharp.IconButton btnBrowse;
        private FontAwesome.Sharp.IconButton btnValidate;
        private Label lblFilePath;
    }
}