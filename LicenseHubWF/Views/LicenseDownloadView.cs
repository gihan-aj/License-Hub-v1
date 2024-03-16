using LicenseHubWF._Repositories;
using LicenseHubWF.Models;
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
    public partial class LicenseDownloadView : Form, ILicenseDownloadView
    {
        private bool _isAvailable;
        private string _licenseStatus;
        private LicenseModel _license;
        private DateTime _requestedDate;
        private string _requestKey;
        private string _dateFormat;

        private event EventHandler _availabilityEvent;
        public LicenseDownloadView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            _dateFormat = ApiRepository.GetSetting<string>("DateFormat");
            TopLevel = false;
        }

        public bool IsAvailable
        {
            set 
            { 
                _isAvailable = value; 
                _availabilityEvent.Invoke(this, EventArgs.Empty);
            }
        }
        public string LicenseStatus 
        { 
            set => _licenseStatus = value; 
        }
        public LicenseModel License
        {
            get => _license;
            set
            {
                _license = value;
                if(License != null)
                {
                    txtLicenseId.Text = _license.LicenseId;
                    txtCustomer.Text = _license.Client;
                    txtStartDate.Text = _license.StartDate.ToString(_dateFormat);
                    txtEndDate.Text = _license.EndDate.ToString(_dateFormat);
                    txtPcName.Text = _license.PcName;
                    txtPackageList.Text = string.Join(Environment.NewLine, _license.PackageList);
                }
            }
        }
        public DateTime RequestedDate
        {
            set
            {
                _requestedDate = value;
                if(_license != null)
                {
                    txtRequestedDate.Text = _requestedDate.ToString(_dateFormat);
                }
            }
        }
        public string RequestKey
        {
            set
            {
                _requestKey = value;
                if(_license != null)
                {
                    txtRequestKey.Text = _requestKey;
                }
            }
        }

        public event EventHandler CheckStatusEvent;
        public event EventHandler DownloadLicenseEvent;
        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate
            {
                btnDownload.Visible = false;
            };

            btnStatus.Click += delegate
            {
                CheckStatusEvent?.Invoke(this, EventArgs.Empty);
            };

            _availabilityEvent += ShowDownloadButton;
        }

        private void ShowDownloadButton(object? sender, EventArgs e)
        {
            if(_isAvailable)
            {
                btnDownload.Visible = true;
            }
            else
            {
                btnDownload.Visible = false;
            }
        }
    }
}
