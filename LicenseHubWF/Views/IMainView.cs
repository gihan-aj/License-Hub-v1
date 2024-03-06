using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IMainView
    {
        event EventHandler ShowLicenseView;
        event EventHandler ShowRequestLicenseView;
        event EventHandler ShowDownloadLicenseView;
        event EventHandler ShowRequestKeyView;
        event EventHandler ShowConfigurationView;
        event EventHandler ShowLoginView;

        void OpenChildForm(Form childForm);
    }
}
