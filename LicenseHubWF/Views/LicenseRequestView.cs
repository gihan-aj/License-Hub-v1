using LicenseHubWF._Repositories;
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
        public LicenseRequestView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            checkedListBoxPackages.CheckOnClick = true;
            checkBoxAgreement.Text = ApiRepository.GetSetting<string>("LicenseAgreementCheckBoxText");
            this.TopLevel = false;
        }

        private void AssociateAndRaiseViewEvents()
        {
            //this.Load += delegate { LoadClientsEvent?.Invoke(this, EventArgs.Empty);  LoadPackagesEvent?.Invoke(this, EventArgs.Empty);};
            linkAgreement.Click += delegate { LicenseAgreementEvent?.Invoke(this, EventArgs.Empty); };

            btnRequest.Click += delegate { RequestLicenseEvent?.Invoke(this, EventArgs.Empty);  };

            btnReset.Click += delegate
            {
                comboBoxClients.SelectedIndex = -1;
                Client = string.Empty;

                if(checkedListBoxPackages.CheckedItems.Count > 0)
                {
                    for(int i = 0; i < checkedListBoxPackages.Items.Count; i++)
                    {
                        checkedListBoxPackages.SetItemChecked(i, false);
                    }
                }
                Packages = [];

                radioButtonFull.Checked = false;
                radioButtonTrial.Checked = false;
                LicenseType = string.Empty;
            };
        }

        // Properties
        public string Client 
        { 
            get 
            {
                ClientModel? client = comboBoxClients.SelectedItem as ClientModel;
                if(client != null)
                {
                    return client.ClientCode;
                }
                else
                {
                    return string.Empty;
                }
                
            } 
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
        public bool IsAgreementAccepted
        {
            get
            {
                return checkBoxAgreement.Checked;
            }

        }

        // Events

        public event EventHandler RequestLicenseEvent;
        public event EventHandler ResetEvent;
        public event EventHandler LicenseAgreementEvent;

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
        //private static LicenseRequestView instance;
        //public static LicenseRequestView GetInstance()
        //{
        //    //if (instance == null || instance.IsDisposed)
        //    //{
        //    //    instance = new LicenseRequestView();
        //    //    instance.MdiParent = parentContainer;
        //    //    instance.Show();
        //    //    instance.Location = new Point(0, 130);
        //    //}
        //    //else
        //    //{
        //    //    if (instance.WindowState == FormWindowState.Minimized)
        //    //    {
        //    //        instance.WindowState = FormWindowState.Normal;
        //    //    }
        //    //    instance.BringToFront();
        //    //}

        //    //if (instance != null)
        //    //{
        //    //    instance.Dispose();
        //    //}

        //    //instance = new LicenseRequestView();
        //    //instance.TopLevel = false;

        //    //return instance;
        //    if( instance == null)
        //    {
        //        instance = new LicenseRequestView();
        //    }
        //    return instance;
        //}

    }
}
