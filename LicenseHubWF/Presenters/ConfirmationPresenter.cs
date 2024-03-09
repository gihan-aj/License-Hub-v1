using LicenseHubWF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Presenters
{
    public class ConfirmationPresenter
    {
        private IConfirmationView _confirmationView;
        private string _warningMessage;

        public ConfirmationPresenter(string warningMessage)
        {
            _confirmationView = new ConfirmationView();
            _warningMessage = warningMessage;
            _confirmationView.WarningMessage = warningMessage;
            _confirmationView.Show();
        }
    }
}
