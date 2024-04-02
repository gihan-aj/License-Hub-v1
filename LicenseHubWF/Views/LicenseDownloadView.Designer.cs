namespace LicenseHubWF.Views
{
    partial class LicenseDownloadView
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
            btnStatus = new FontAwesome.Sharp.IconButton();
            btnDownload = new FontAwesome.Sharp.IconButton();
            groupBoxStatus = new GroupBox();
            lblLicenseStatus = new Label();
            groupBoxLicense = new GroupBox();
            txtRequestKey = new TextBox();
            label2 = new Label();
            txtRequestedDate = new TextBox();
            label1 = new Label();
            txtPackageList = new TextBox();
            lblPackageList = new Label();
            txtPcName = new TextBox();
            txtEndDate = new TextBox();
            txtStartDate = new TextBox();
            lblStartDate = new Label();
            lblEndDate = new Label();
            lblPcName = new Label();
            txtCustomer = new TextBox();
            txtLicenseId = new TextBox();
            lblCustomer = new Label();
            lblLicenseId = new Label();
            groupBoxStatus.SuspendLayout();
            groupBoxLicense.SuspendLayout();
            SuspendLayout();
            // 
            // btnStatus
            // 
            btnStatus.BackColor = Color.FromArgb(88, 40, 65);
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStatus.ForeColor = SystemColors.Window;
            btnStatus.IconChar = FontAwesome.Sharp.IconChar.None;
            btnStatus.IconColor = Color.Black;
            btnStatus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStatus.Location = new Point(38, 430);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(280, 30);
            btnStatus.TabIndex = 14;
            btnStatus.Text = "Check Status";
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(88, 40, 65);
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.ForeColor = SystemColors.Window;
            btnDownload.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDownload.IconColor = Color.Black;
            btnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDownload.Location = new Point(358, 430);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(280, 30);
            btnDownload.TabIndex = 15;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = false;
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Controls.Add(lblLicenseStatus);
            groupBoxStatus.Location = new Point(38, 19);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(600, 56);
            groupBoxStatus.TabIndex = 16;
            groupBoxStatus.TabStop = false;
            // 
            // lblLicenseStatus
            // 
            lblLicenseStatus.AutoSize = true;
            lblLicenseStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseStatus.Location = new Point(6, 21);
            lblLicenseStatus.Name = "lblLicenseStatus";
            lblLicenseStatus.Size = new Size(95, 17);
            lblLicenseStatus.TabIndex = 1;
            lblLicenseStatus.Text = "License Status";
            // 
            // groupBoxLicense
            // 
            groupBoxLicense.Controls.Add(txtRequestKey);
            groupBoxLicense.Controls.Add(label2);
            groupBoxLicense.Controls.Add(txtRequestedDate);
            groupBoxLicense.Controls.Add(label1);
            groupBoxLicense.Controls.Add(txtPackageList);
            groupBoxLicense.Controls.Add(lblPackageList);
            groupBoxLicense.Controls.Add(txtPcName);
            groupBoxLicense.Controls.Add(txtEndDate);
            groupBoxLicense.Controls.Add(txtStartDate);
            groupBoxLicense.Controls.Add(lblStartDate);
            groupBoxLicense.Controls.Add(lblEndDate);
            groupBoxLicense.Controls.Add(lblPcName);
            groupBoxLicense.Controls.Add(txtCustomer);
            groupBoxLicense.Controls.Add(txtLicenseId);
            groupBoxLicense.Controls.Add(lblCustomer);
            groupBoxLicense.Controls.Add(lblLicenseId);
            groupBoxLicense.Location = new Point(38, 81);
            groupBoxLicense.Name = "groupBoxLicense";
            groupBoxLicense.Size = new Size(600, 331);
            groupBoxLicense.TabIndex = 17;
            groupBoxLicense.TabStop = false;
            // 
            // txtRequestKey
            // 
            txtRequestKey.BorderStyle = BorderStyle.FixedSingle;
            txtRequestKey.ForeColor = Color.FromArgb(88, 40, 65);
            txtRequestKey.Location = new Point(0, 284);
            txtRequestKey.Name = "txtRequestKey";
            txtRequestKey.ReadOnly = true;
            txtRequestKey.Size = new Size(600, 25);
            txtRequestKey.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 264);
            label2.Name = "label2";
            label2.Size = new Size(83, 17);
            label2.TabIndex = 23;
            label2.Text = "Request Key";
            // 
            // txtRequestedDate
            // 
            txtRequestedDate.BorderStyle = BorderStyle.FixedSingle;
            txtRequestedDate.ForeColor = Color.FromArgb(88, 40, 65);
            txtRequestedDate.Location = new Point(0, 220);
            txtRequestedDate.Name = "txtRequestedDate";
            txtRequestedDate.ReadOnly = true;
            txtRequestedDate.Size = new Size(280, 25);
            txtRequestedDate.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 200);
            label1.Name = "label1";
            label1.Size = new Size(105, 17);
            label1.TabIndex = 21;
            label1.Text = "Requested Date";
            // 
            // txtPackageList
            // 
            txtPackageList.BorderStyle = BorderStyle.FixedSingle;
            txtPackageList.ForeColor = Color.FromArgb(88, 40, 65);
            txtPackageList.Location = new Point(320, 100);
            txtPackageList.Multiline = true;
            txtPackageList.Name = "txtPackageList";
            txtPackageList.ReadOnly = true;
            txtPackageList.Size = new Size(280, 146);
            txtPackageList.TabIndex = 20;
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPackageList.Location = new Point(320, 77);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(64, 17);
            lblPackageList.TabIndex = 19;
            lblPackageList.Text = "Packages";
            // 
            // txtPcName
            // 
            txtPcName.BorderStyle = BorderStyle.FixedSingle;
            txtPcName.ForeColor = Color.FromArgb(88, 40, 65);
            txtPcName.Location = new Point(0, 158);
            txtPcName.Name = "txtPcName";
            txtPcName.ReadOnly = true;
            txtPcName.Size = new Size(280, 25);
            txtPcName.TabIndex = 18;
            // 
            // txtEndDate
            // 
            txtEndDate.BorderStyle = BorderStyle.FixedSingle;
            txtEndDate.ForeColor = Color.FromArgb(88, 40, 65);
            txtEndDate.Location = new Point(155, 95);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ReadOnly = true;
            txtEndDate.Size = new Size(126, 25);
            txtEndDate.TabIndex = 17;
            // 
            // txtStartDate
            // 
            txtStartDate.BorderStyle = BorderStyle.FixedSingle;
            txtStartDate.ForeColor = Color.FromArgb(88, 40, 65);
            txtStartDate.Location = new Point(0, 95);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ReadOnly = true;
            txtStartDate.Size = new Size(126, 25);
            txtStartDate.TabIndex = 16;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartDate.Location = new Point(0, 75);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(70, 17);
            lblStartDate.TabIndex = 15;
            lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDate.Location = new Point(155, 75);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(64, 17);
            lblEndDate.TabIndex = 14;
            lblEndDate.Text = "End Date";
            // 
            // lblPcName
            // 
            lblPcName.AutoSize = true;
            lblPcName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPcName.Location = new Point(0, 138);
            lblPcName.Name = "lblPcName";
            lblPcName.Size = new Size(64, 17);
            lblPcName.TabIndex = 13;
            lblPcName.Text = "PC Name";
            // 
            // txtCustomer
            // 
            txtCustomer.BorderStyle = BorderStyle.FixedSingle;
            txtCustomer.ForeColor = Color.FromArgb(88, 40, 65);
            txtCustomer.Location = new Point(320, 32);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(280, 25);
            txtCustomer.TabIndex = 12;
            // 
            // txtLicenseId
            // 
            txtLicenseId.BorderStyle = BorderStyle.FixedSingle;
            txtLicenseId.ForeColor = Color.FromArgb(88, 40, 65);
            txtLicenseId.Location = new Point(0, 32);
            txtLicenseId.Name = "txtLicenseId";
            txtLicenseId.ReadOnly = true;
            txtLicenseId.Size = new Size(280, 25);
            txtLicenseId.TabIndex = 11;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(320, 12);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(67, 17);
            lblCustomer.TabIndex = 10;
            lblCustomer.Text = "Customer";
            // 
            // lblLicenseId
            // 
            lblLicenseId.AutoSize = true;
            lblLicenseId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseId.Location = new Point(0, 12);
            lblLicenseId.Name = "lblLicenseId";
            lblLicenseId.Size = new Size(71, 17);
            lblLicenseId.TabIndex = 9;
            lblLicenseId.Text = "License ID";
            // 
            // LicenseDownloadView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 500);
            Controls.Add(groupBoxLicense);
            Controls.Add(groupBoxStatus);
            Controls.Add(btnDownload);
            Controls.Add(btnStatus);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(243, 111, 56);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LicenseDownloadView";
            Text = "LicenseDownloadView";
            groupBoxStatus.ResumeLayout(false);
            groupBoxStatus.PerformLayout();
            groupBoxLicense.ResumeLayout(false);
            groupBoxLicense.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnStatus;
        private FontAwesome.Sharp.IconButton btnDownload;
        private GroupBox groupBoxStatus;
        private Label lblLicenseStatus;
        private GroupBox groupBoxLicense;
        private TextBox txtCustomer;
        private TextBox txtLicenseId;
        private Label lblCustomer;
        private Label lblLicenseId;
        private TextBox txtPcName;
        private TextBox txtEndDate;
        private TextBox txtStartDate;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblPcName;
        private TextBox txtPackageList;
        private Label lblPackageList;
        private Label label1;
        private TextBox txtRequestKey;
        private Label label2;
        private TextBox txtRequestedDate;
    }
}