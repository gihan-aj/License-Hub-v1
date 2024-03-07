using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LicenseHubWF._Repositories;
using LoggerLib;

namespace LicenseHubWF.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private Form? activeForm;
        private string? baseUrl;
        private IFileLogger logger;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;

            // Events
            this.mainView.ShowRequestLicenseView += ShowRequestLicenseView;
            this.mainView.ShowLoginView += ShowLoginView;

            logger = new FileLogger();
            baseUrl = ApiRepository.GetAPIBaseUrl(logger);
            if(baseUrl != null)
            {
                ApiRepository.InitializeClient(baseUrl);
            }

        }

        private void ShowLoginView(object? sender, EventArgs e)
        {
            ILoginView loginView = new LoginView();
            ILoginRepository loginRepository = new LoginRepository(logger);
            new LoginPresenter(loginView, loginRepository, logger);
        }

        private void ShowRequestLicenseView(object? sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ILicenseRequestView view = LicenseRequestView.GetInstance();
            activeForm = (Form)view;


            ILicenseRequestRepository repository = new LicenseRequestRepository("1234", logger);
            new LicenseRequestPresenter(view, repository, logger);

            mainView.OpenChildForm((Form)view);

        }
    }
}
