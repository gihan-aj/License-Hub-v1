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
    public partial class LoginView : Form, ILoginView
    {
        private static LoginView? instance;
        public LoginView()
        {
            InitializeComponent();

            btnLogin.Click += delegate { LoginEvent?.Invoke(this, EventArgs.Empty); };
            btnReset.Click += delegate { Email = ""; Password = ""; };
            btnClose.Click += delegate { this.Close(); };
        }

        public string Email 
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; } 
        }
        public string Password 
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public event EventHandler? LoginEvent;

        public static LoginView GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new LoginView();
            }
            else
            {
                instance.BringToFront();
            }
             return instance;
        }

        // Singleton pattern (Open a single form instance)
        //private static LoginView? instance;
        //public static LoginView GetInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //    {
        //        instance = new LoginView();
        //    }
        //    else
        //    {
        //        if (instance.WindowState == FormWindowState.Minimized)
        //        {
        //            instance.WindowState = FormWindowState.Normal;
        //        }
        //        instance.BringToFront();
        //    }

        //    //if (instance != null)
        //    //{
        //    //    instance.Dispose();
        //    //}

        //    //instance = new LicenseRequestView();
        //    //instance.TopLevel = false;

        //    return instance;
        //}
    }
}
