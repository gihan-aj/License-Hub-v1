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
    public partial class MessageBoxView : Form, IMessageBoxView
    {
        private string _title = "Info";
        private string _message = string.Empty;
        private bool _success = false;

        public MessageBoxView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

        }

        public string Title 
        { 
            set 
            {
                _title = value;
                if(_title == "Confirmation")
                {
                    btnAccept.Visible = true;
                    btnDecline.Visible = true;
                    btnOk.Visible = false;
                    messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
                    messageBoxTitle.Text = ApiRepository.GetSetting<string>("MessageBoxTitleConfirmation");
                }
                if (_title == "Info")
                {
                    btnAccept.Visible = false;
                    btnDecline.Visible = false;
                    btnOk.Visible = true;
                    messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
                    messageBoxTitle.Text = ApiRepository.GetSetting<string>("MessageBoxTitleInfo"); ;
                }
                if (_title == "Error")
                {
                    btnAccept.Visible = false;
                    btnDecline.Visible = false;
                    btnOk.Visible = true; 
                    messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.CircleStop;
                    messageBoxTitle.Text = ApiRepository.GetSetting<string>("MessageBoxTitleError"); ;
                }
            } 
        }
        public string Message 
        { 
            set
            {
                _message = value;
                if(_message.Length > 80)
                {
                    lblMessage.Text = _message;
                }
                else
                {
                    lblMessage.Text = _message;

                }
            } 
        }
        public bool IsAccepted { 
            get => _success;  
        }

        public event EventHandler ClickEvent;

        private void AssociateAndRaiseViewEvents()
        {
            btnAccept.Click += delegate
            {
                _success = true;
                ClickEvent?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            };
            btnDecline.Click += delegate
            {
                _success = false;
                ClickEvent?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            };
            btnOk.Click += delegate
            {
                ClickEvent?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            };
        }
    }
}
