namespace LicenseHubWF.Views
{
    partial class ConfigurationView
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
            lblServer = new Label();
            txtServer = new TextBox();
            lblTestMessage = new Label();
            btnTest = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServer.Location = new Point(40, 45);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(47, 17);
            lblServer.TabIndex = 8;
            lblServer.Text = "Server";
            // 
            // txtServer
            // 
            txtServer.BorderStyle = BorderStyle.FixedSingle;
            txtServer.ForeColor = Color.FromArgb(88, 40, 65);
            txtServer.Location = new Point(40, 75);
            txtServer.Name = "txtServer";
            txtServer.ReadOnly = true;
            txtServer.Size = new Size(600, 25);
            txtServer.TabIndex = 9;
            // 
            // lblTestMessage
            // 
            lblTestMessage.Location = new Point(40, 114);
            lblTestMessage.Name = "lblTestMessage";
            lblTestMessage.Size = new Size(600, 165);
            lblTestMessage.TabIndex = 11;
            lblTestMessage.Text = "label1";
            // 
            // btnTest
            // 
            btnTest.BackColor = Color.FromArgb(88, 40, 65);
            btnTest.FlatAppearance.BorderSize = 0;
            btnTest.FlatStyle = FlatStyle.Flat;
            btnTest.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTest.ForeColor = SystemColors.Window;
            btnTest.IconChar = FontAwesome.Sharp.IconChar.None;
            btnTest.IconColor = Color.Black;
            btnTest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTest.Location = new Point(360, 430);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(280, 30);
            btnTest.TabIndex = 12;
            btnTest.Text = "Test Connection";
            btnTest.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(88, 40, 65);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = SystemColors.Window;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEdit.IconColor = Color.Black;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.Location = new Point(40, 430);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(280, 30);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(88, 40, 65);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.Window;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(40, 430);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(280, 30);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // ConfigurationView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 500);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(btnTest);
            Controls.Add(lblTestMessage);
            Controls.Add(txtServer);
            Controls.Add(lblServer);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(243, 111, 56);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConfigurationView";
            Text = "ConfigurationView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblServer;
        private TextBox txtServer;
        private Label lblTestMessage;
        private FontAwesome.Sharp.IconButton btnTest;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnSave;
    }
}