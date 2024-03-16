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
        private string _currentPageName;
        public MainView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

        }

        private void AssociateAndRaiseViewEvents()
        {
            // Generate events
            btnViewLicense.Click += delegate { ShowLicenseView?.Invoke(this, EventArgs.Empty); };
            btnRequestLicense.Click += delegate { ShowRequestLicenseView?.Invoke(this, EventArgs.Empty); };
            btnDownloadLicense.Click += delegate { ShowDownloadLicenseView?.Invoke(this, EventArgs.Empty); };
            btnRequestKey.Click += delegate { ShowRequestKeyView?.Invoke(this, EventArgs.Empty); };
            btnConfiguration.Click += delegate { ShowConfigurationView?.Invoke(this, EventArgs.Empty); };

            btnLogin.Click += delegate { ShowLoginView?.Invoke(this, EventArgs.Empty); };
            btnLogout.Click += delegate { LogoutEvent?.Invoke(this, EventArgs.Empty); };

            ApiRepository.UserChanged += OnUserChanged;
            ApiRepository.ConnectivityChanged += OnConnectivityChanged;

            btnClose.Click += delegate { this.Dispose(); };
            btnMinimize.Click += delegate { this.WindowState = FormWindowState.Minimized; };

            btnLogin.Visible = true;
            btnLogout.Visible = false;

            lblPageName.Text = string.Empty;
        }

        public string CurrentPageName
        {
            set
            {
                _currentPageName = value;
                lblPageName.Text = _currentPageName.ToUpper();
            }
        }

        private void OnConnectivityChanged(object? sender, EventArgs e)
        {
            if (ApiRepository.Connectivity)
            {
                iconConnectivity.Visible = true;
                iconNoConnectivity.Visible = false;
            }
            else
            {
                iconConnectivity.Visible = false;
                iconNoConnectivity.Visible = true;
            }
        }

        private void OnUserChanged(object? sender, EventArgs e)
        {
            if(ApiRepository.User != null)
            {
                lblUsername.Text = ApiRepository.User.Name;
                btnLogin.Visible = false;
                btnLogout.Visible = true;
            }
            else
            {
                lblUsername.Text = "Guest";
                btnLogin.Visible = true;
                btnLogout.Visible = false;
            }
        }

        public event EventHandler ShowLicenseView;
        public event EventHandler ShowRequestLicenseView;
        public event EventHandler ShowDownloadLicenseView;
        public event EventHandler ShowRequestKeyView;
        public event EventHandler ShowConfigurationView;
        public event EventHandler ShowLoginView;
        public event EventHandler LogoutEvent;

        public void OpenChildForm(Form childForm)
        {
            this.panelChildFormWindow.Controls.Add(childForm);
            this.panelChildFormWindow.Tag = childForm;
            childForm.Show();
 
        }
    }
}
