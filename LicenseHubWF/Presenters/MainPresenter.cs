using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LicenseHubWF._Repositories;

namespace LicenseHubWF.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private Form activeForm;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            this.mainView.ShowRequestLicenseView += ShowRequestLicenseView;
        }

        private void ShowRequestLicenseView(object? sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ILicenseRequestView view = LicenseRequestView.GetInstance();
            activeForm = (Form)view;


            ILicenseRequestRepository repository = new LicenseRequestRepository("1234");
            new LicenseRequestPresenter(view, repository);

            mainView.OpenChildForm((Form)view);

        }
    }
}
