namespace LicenseHubWF.Views
{
    partial class LicenseRequestView
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
            labelClient = new Label();
            comboBoxClients = new ComboBox();
            groupBoxVersion = new GroupBox();
            radioButtonFull = new RadioButton();
            radioButtonTrial = new RadioButton();
            labelComputerName = new Label();
            labelRequestKey = new Label();
            textBoxComputerName = new TextBox();
            textBoxRequestKey = new TextBox();
            checkedListBoxPackages = new CheckedListBox();
            labelPackages = new Label();
            btnRequest = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            groupBoxVersion.SuspendLayout();
            SuspendLayout();
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Location = new Point(40, 40);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(44, 19);
            labelClient.TabIndex = 0;
            labelClient.Text = "Client";
            // 
            // comboBoxClients
            // 
            comboBoxClients.ForeColor = Color.FromArgb(88, 40, 65);
            comboBoxClients.FormattingEnabled = true;
            comboBoxClients.Location = new Point(40, 70);
            comboBoxClients.Name = "comboBoxClients";
            comboBoxClients.Size = new Size(280, 25);
            comboBoxClients.TabIndex = 1;
            // 
            // groupBoxVersion
            // 
            groupBoxVersion.Controls.Add(radioButtonFull);
            groupBoxVersion.Controls.Add(radioButtonTrial);
            groupBoxVersion.FlatStyle = FlatStyle.Flat;
            groupBoxVersion.ForeColor = Color.FromArgb(88, 40, 65);
            groupBoxVersion.Location = new Point(40, 120);
            groupBoxVersion.Name = "groupBoxVersion";
            groupBoxVersion.Size = new Size(280, 80);
            groupBoxVersion.TabIndex = 2;
            groupBoxVersion.TabStop = false;
            groupBoxVersion.Text = "Version";
            // 
            // radioButtonFull
            // 
            radioButtonFull.AutoSize = true;
            radioButtonFull.FlatStyle = FlatStyle.Flat;
            radioButtonFull.Location = new Point(160, 30);
            radioButtonFull.Name = "radioButtonFull";
            radioButtonFull.Size = new Size(96, 23);
            radioButtonFull.TabIndex = 1;
            radioButtonFull.TabStop = true;
            radioButtonFull.Text = "Full Version";
            radioButtonFull.UseVisualStyleBackColor = true;
            // 
            // radioButtonTrial
            // 
            radioButtonTrial.AutoSize = true;
            radioButtonTrial.FlatStyle = FlatStyle.Flat;
            radioButtonTrial.Location = new Point(20, 30);
            radioButtonTrial.Name = "radioButtonTrial";
            radioButtonTrial.Size = new Size(99, 23);
            radioButtonTrial.TabIndex = 0;
            radioButtonTrial.TabStop = true;
            radioButtonTrial.Text = "Trial Version";
            radioButtonTrial.UseVisualStyleBackColor = true;
            // 
            // labelComputerName
            // 
            labelComputerName.AutoSize = true;
            labelComputerName.Location = new Point(40, 220);
            labelComputerName.Name = "labelComputerName";
            labelComputerName.Size = new Size(111, 19);
            labelComputerName.TabIndex = 3;
            labelComputerName.Text = "Computer Name";
            // 
            // labelRequestKey
            // 
            labelRequestKey.AutoSize = true;
            labelRequestKey.Location = new Point(40, 295);
            labelRequestKey.Name = "labelRequestKey";
            labelRequestKey.Size = new Size(84, 19);
            labelRequestKey.TabIndex = 4;
            labelRequestKey.Text = "Request Key";
            // 
            // textBoxComputerName
            // 
            textBoxComputerName.BorderStyle = BorderStyle.FixedSingle;
            textBoxComputerName.ForeColor = Color.FromArgb(88, 40, 65);
            textBoxComputerName.Location = new Point(40, 250);
            textBoxComputerName.Name = "textBoxComputerName";
            textBoxComputerName.ReadOnly = true;
            textBoxComputerName.Size = new Size(280, 25);
            textBoxComputerName.TabIndex = 5;
            // 
            // textBoxRequestKey
            // 
            textBoxRequestKey.BorderStyle = BorderStyle.FixedSingle;
            textBoxRequestKey.ForeColor = Color.FromArgb(88, 40, 65);
            textBoxRequestKey.Location = new Point(40, 325);
            textBoxRequestKey.Name = "textBoxRequestKey";
            textBoxRequestKey.ReadOnly = true;
            textBoxRequestKey.Size = new Size(280, 25);
            textBoxRequestKey.TabIndex = 6;
            // 
            // checkedListBoxPackages
            // 
            checkedListBoxPackages.BorderStyle = BorderStyle.FixedSingle;
            checkedListBoxPackages.ForeColor = Color.FromArgb(88, 40, 65);
            checkedListBoxPackages.FormattingEnabled = true;
            checkedListBoxPackages.Location = new Point(360, 70);
            checkedListBoxPackages.Name = "checkedListBoxPackages";
            checkedListBoxPackages.Size = new Size(280, 282);
            checkedListBoxPackages.TabIndex = 7;
            // 
            // labelPackages
            // 
            labelPackages.AutoSize = true;
            labelPackages.Location = new Point(360, 40);
            labelPackages.Name = "labelPackages";
            labelPackages.Size = new Size(65, 19);
            labelPackages.TabIndex = 8;
            labelPackages.Text = "Packages";
            // 
            // btnRequest
            // 
            btnRequest.BackColor = Color.FromArgb(88, 40, 65);
            btnRequest.FlatAppearance.BorderSize = 0;
            btnRequest.FlatStyle = FlatStyle.Flat;
            btnRequest.ForeColor = SystemColors.Window;
            btnRequest.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRequest.IconColor = Color.Black;
            btnRequest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRequest.Location = new Point(360, 370);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(280, 30);
            btnRequest.TabIndex = 9;
            btnRequest.Text = "Request";
            btnRequest.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = Color.FromArgb(88, 40, 65);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(360, 406);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(280, 30);
            iconButton1.TabIndex = 10;
            iconButton1.Text = "Reset";
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // LicenseRequestView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(680, 470);
            Controls.Add(iconButton1);
            Controls.Add(btnRequest);
            Controls.Add(labelPackages);
            Controls.Add(checkedListBoxPackages);
            Controls.Add(textBoxRequestKey);
            Controls.Add(textBoxComputerName);
            Controls.Add(labelRequestKey);
            Controls.Add(labelComputerName);
            Controls.Add(groupBoxVersion);
            Controls.Add(comboBoxClients);
            Controls.Add(labelClient);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(243, 111, 56);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LicenseRequestView";
            Text = "LicenseRequestView";
            groupBoxVersion.ResumeLayout(false);
            groupBoxVersion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelClient;
        private ComboBox comboBoxClients;
        private GroupBox groupBoxVersion;
        private RadioButton radioButtonFull;
        private RadioButton radioButtonTrial;
        private Label labelComputerName;
        private Label labelRequestKey;
        private TextBox textBoxComputerName;
        private TextBox textBoxRequestKey;
        private CheckedListBox checkedListBoxPackages;
        private Label labelPackages;
        private FontAwesome.Sharp.IconButton btnRequest;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}