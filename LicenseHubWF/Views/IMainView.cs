using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IMainView
    {
        string CurrentPageName { set; }

        event EventHandler? ShowLicenseView;
        event EventHandler? ShowRequestLicenseView;
        event EventHandler? ShowDownloadLicenseView;
        event EventHandler? ShowRequestKeyView;
        event EventHandler? ShowConfigurationView;
        event EventHandler? ShowLoginView;
        event EventHandler? LogoutEvent;

        void OnUserChanged(object? sender, EventArgs e);
        void OnConnectivityChanged(object? sender, EventArgs e);
        void OpenChildForm(Form childForm);
        void RemoveChildForm(object? sender, EventArgs e);
    }
}
