using LicenseHubWF._Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseHubWF.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();

            // Generate events
            btnRequestLicense.Click += delegate { ShowRequestLicenseView?.Invoke(this, EventArgs.Empty); };
            btnLogin.Click += delegate { ShowLoginView?.Invoke(this, EventArgs.Empty); };

            btnClose.Click += delegate { this.Dispose(); };
            btnMinimize.Click += delegate { this.WindowState = FormWindowState.Minimized; };
            
        }

        public string UserName 
        {
            get => lblUsername.Text;
            set { lblUsername.Text = value; }
        }

        public event EventHandler ShowLicenseView;
        public event EventHandler ShowRequestLicenseView;
        public event EventHandler ShowDownloadLicenseView;
        public event EventHandler ShowRequestKeyView;
        public event EventHandler ShowConfigurationView;
        public event EventHandler ShowLoginView;

        public void OpenChildForm(Form childForm)
        {
            this.panelChildFormWindow.Controls.Add(childForm);
            this.panelChildFormWindow.Tag = childForm;
        }
    }
}
