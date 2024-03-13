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
using System.Windows.Input;

namespace LicenseHubWF.Views
{
    public partial class ConfigurationView : Form, IConfigurationView
    {
        private string _baseAddress;
        private bool _isSaved;
        public ConfigurationView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            this.TopLevel = false;
        }

        public string BaseAdsress 
        { 
            get => _baseAddress;         
        }
        public string TestMessage 
        { 
            set
            {
                lblTestMessage.Text = value;
            } 
        }

        public bool IsSaved
        {
            set
            {
                _isSaved = value;
                if (_isSaved)
                {
                    txtServer.ReadOnly = true;
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                }
            }
        }

        public event EventHandler TestEvent;
        public event EventHandler SaveEvent;

        private void AssociateAndRaiseViewEvents()
        {

            this.Load += delegate
            {
                txtServer.Text = ApiRepository.GetSetting<string>("ApiBaseUrl");
                lblTestMessage.Text = string.Empty;
                btnSave.Visible = false;
                btnEdit.Visible = true;
                txtServer.ReadOnly = true;
                
            };

            btnEdit.Click += delegate 
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
                txtServer.ReadOnly = false;
                lblTestMessage.Text = string.Empty;
                btnTest.Visible = false;
                _isSaved = false;
            };

            btnSave.Click += delegate
            {
                _baseAddress = txtServer.Text;
                SaveEvent?.Invoke(this, EventArgs.Empty);
                btnTest.Visible = true;
            };

            btnTest.Click += delegate { TestEvent?.Invoke(this, EventArgs.Empty); };

        }
    }
}
