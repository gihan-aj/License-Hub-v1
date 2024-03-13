using LicenseHubWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface ILicenseDownloadView
    {
        bool IsAvailable { set; }
        string LicenseStatus { set; }
        LicenseModel License { get;  set; }
        DateTime RequestedDate { set; }
        string RequestKey { set; }

        event EventHandler CheckStatusEvent;
        event EventHandler DownloadLicenseEvent;
    }
}
