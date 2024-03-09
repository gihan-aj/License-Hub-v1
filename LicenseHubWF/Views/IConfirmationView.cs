using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IConfirmationView
    {
        string? WarningMessage { set; }
        bool IsAccepted { get; set; }

        event EventHandler AcceptOrCancelEvent;

        void Show();
        void Close();
    }
}
