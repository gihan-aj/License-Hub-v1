using LicenseHubWF._Repositories;
using Microsoft.VisualBasic;
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
    public partial class RequestKeyView : Form, IRequestKeyView
    {
        private string _key;
        public RequestKeyView()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            TopLevel = false;
        }

        public string Key
        {
            set { _key = value; }
        }

        public event EventHandler ShowRequestKey;

        private void AssociateAndRaiseEvents()
        {
            iconCopied.Visible = false;

            this.Load += delegate 
            { 
                ShowRequestKey?.Invoke(this, EventArgs.Empty); 
                txtRequestKey.Text = _key;
            };

            btnCopy.Click += delegate 
            {
                Clipboard.SetText(_key);
                iconCopied.Visible = true;
            };

            lblRequestKeyMessage.Text = ApiRepository.GetSetting<string>("RequestKeyInfo");

        }
    }
}
