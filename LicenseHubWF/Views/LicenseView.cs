using LicenseHubWF._Repositories;
using LicenseHubWF.Models;
using LoggerLib;
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
    public partial class LicenseView : Form, ILicenseView
    {
        private string dateFormat = string.Empty;
        private string filePath = string.Empty;
        private LicenseModel license;
        private static LicenseView instance;

        public LicenseView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate { LoadLicenseEvent?.Invoke(this, EventArgs.Empty); };
            btnBrowse.Click += delegate { BrowseEvent?.Invoke(this, EventArgs.Empty); };
            btnValidate.Click += delegate { ValidateEvent?.Invoke(this, EventArgs.Empty); };

            dateFormat = ApiRepository.GetSetting<string>("DateFormat");

            this.TopLevel = false;
            lblNotification.Text = string.Empty;
            lblFilePath.Text = string.Empty;
        }

        public string FilePath 
        { 
            get => filePath;
            set 
            {
                filePath = value;

                if(filePath != string.Empty && filePath.Length > 80)
                {
                    lblFilePath.Text = string.Concat("File Path: ...", filePath.Substring(filePath.Length - 80));
                }
                else
                {
                    lblFilePath.Text = string.Concat("File Path: ",filePath);
                }
            } 
        }
        public LicenseModel License 
        {
            get => license;
            set 
            {
                license = value;
                txtLicenseId.Text = license.LicenseId;
                txtCustomer.Text = license.Customer;
                txtStartDate.Text = license.StartDate.ToString(dateFormat);
                txtEndDate.Text = license.EndDate.ToString(dateFormat);
                txtPcName.Text = license.PcName;
                txtPackageList.Text = string.Join(Environment.NewLine, license.PackageList);
            } 
        }

        public event EventHandler BrowseEvent;
        public event EventHandler ValidateEvent;
        public event EventHandler LoadLicenseEvent;

        public static LicenseView GetInsatance()
        {
            if(instance == null)
            {
                instance = new LicenseView();
            }
            return instance;
        }
    }
}
