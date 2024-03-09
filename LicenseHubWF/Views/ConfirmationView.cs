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
    public partial class ConfirmationView : Form, IConfirmationView
    {
        private bool isAccepted;
        // private static ConfirmationView? instance;

        public ConfirmationView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public string? WarningMessage
        {
            set
            {
                txtWarningMessage.Text = value;
            }
        }
        public bool IsAccepted { 
            get => isAccepted;
            set
            {
                isAccepted = value;
            }
        }

        public event EventHandler? AcceptOrCancelEvent;

        private void AssociateAndRaiseViewEvents()
        {

            btnAccept.Click += delegate
            {
                IsAccepted = true;
                AcceptOrCancelEvent?.Invoke(this, EventArgs.Empty);  
                this.Dispose();
            };
            btnDecline.Click += delegate
            {
                IsAccepted = false;
                AcceptOrCancelEvent?.Invoke(this, EventArgs.Empty);              
                this.Dispose();
            };

        }

        //public static ConfirmationView? GetInstance()
        //{
        //    if (instance != null) {
        //        instance.Dispose();
        //    }
        //    instance = new ConfirmationView();
        //    return instance;
          
        //}

    }
}
