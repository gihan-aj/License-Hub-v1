using LicenseHubWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface ILicenseView
    {
        public string FilePath { get; set; }
        public LicenseModel License { get; set; }

        event EventHandler BrowseEvent;
        event EventHandler ValidateEvent;
        event EventHandler LoadLicenseEvent;

        void Show();
        void Dispose();
    }
}
