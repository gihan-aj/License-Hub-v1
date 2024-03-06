using LicenseHubWF.Models;
using LoggerLib;
using Microsoft.Windows.Themes;
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
    public partial class LicenseRequestView : Form , ILicenseRequestView
    {
        enum Version
        {
            Trial,
            Full
        }

        public LicenseRequestView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            checkedListBoxPackages.CheckOnClick = true;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnRequest.Click += delegate { RequestLicenseEvent?.Invoke(this, EventArgs.Empty);  };
        }

        // Properties
        public ClientModel Client 
        { 
            get { return (ClientModel)comboBoxClients.SelectedItem; } 
            set { } 
        }

        public string RequestKey 
        {
            get { return textBoxRequestKey.Text; }
            set { textBoxRequestKey.Text = value; }
        }

        public string PCName
        {
            get { return textBoxComputerName.Text; }
            set { textBoxComputerName.Text = value; }
           
        }

        public string LicenseType {
            get
            {
                if (radioButtonFull.Checked) return "Full";
                if (radioButtonTrial.Checked) return "Trial";
                return null;
            }
            set { }
        }
        public List<string> Packages
        { 
            get
            {
                var selectedPackages = new List<string>();

                if (checkedListBoxPackages.CheckedItems.Count > 0)
                {
                    foreach (var item in checkedListBoxPackages.CheckedItems)
                    {
                        selectedPackages.Add(item.ToString().Split(":")[0].Trim());
                    };
                }

                return selectedPackages;

            } 
            set { } 
        }

        // Events

        public event EventHandler RequestLicenseEvent;

        // Methods

        public void SetClientList(IEnumerable<ClientModel> clientList)
        {

            comboBoxClients.DataSource = clientList;
            comboBoxClients.DisplayMember = "ClientName";
            comboBoxClients.ValueMember = "ClientCode";

        }

        public void SetPackageList(IEnumerable<PackageModel> packageList)
        {

            foreach (PackageModel item in packageList)
            {
                checkedListBoxPackages.Items.Add($"{item.PackageCode} : {item.PackageName}");
            }

        }

        // Singleton pattern (Open a single form instance)
        private static LicenseRequestView instance;
        public static LicenseRequestView GetInstance()
        {
            //if( instance == null || instance.IsDisposed)
            //{
            //    instance = new LicenseRequestView();
            //    instance.MdiParent = parentContainer;
            //    instance.Show();
            //    instance.Location = new Point(0, 130);
            //}
            //else
            //{
            //    if (instance.WindowState == FormWindowState.Minimized)
            //    {
            //        instance.WindowState = FormWindowState.Normal;
            //    }
            //    instance.BringToFront();
            //}

            if (instance != null)
            {
                instance.Dispose();
            }

            instance = new LicenseRequestView();
            instance.TopLevel = false;

            return instance;
        }

    }
}
