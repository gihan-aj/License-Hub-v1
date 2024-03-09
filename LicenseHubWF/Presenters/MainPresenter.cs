using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LicenseHubWF._Repositories;
using LoggerLib;
using System.Windows.Forms;
using System.Configuration;

namespace LicenseHubWF.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private IMainRepository mainRepository;
        private Form? activeForm;
        private string? baseUrl;
        private IFileLogger logger;

        public MainPresenter(IMainView mainView, IMainRepository mainRepository, IFileLogger logger)
        {
            this.mainView = mainView;
            this.mainRepository = mainRepository;
            this.logger = logger;

            // Events
            this.mainView.ShowRequestLicenseView += ShowRequestLicenseView;
            this.mainView.ShowLoginView += ShowLoginView;
            this.mainView.LogoutEvent += LogoutAndRemoveSessionToken;

            logger = new FileLogger();
            baseUrl = ApiRepository.GetAppSetting("ApiBaseUrl");
            if(baseUrl != null)
            {
                ApiRepository.InitializeClient(baseUrl);
                ApiRepository.IsConnected(logger);
            }

        }

        private async void LogoutAndRemoveSessionToken(object? sender, EventArgs e)
        {
            try
            {
                IConfirmationView confirmationView = new ConfirmationView();
                confirmationView.WarningMessage = ApiRepository.GetAppSetting("LogoutConfirmationMessage");
                confirmationView.Show();

                confirmationView.AcceptOrCancelEvent += async delegate 
                {
                    if (confirmationView.IsAccepted)
                    {
                        LogoutModel logoutDetails = await mainRepository.Logout();

                        logger.LogInfo($"LogoutAndRemoveSessionToken -> {logoutDetails.Message}");

                        if (logoutDetails != null)
                        {
                            if (logoutDetails.Success)
                            {
                                ApiRepository.SessionToken = null;
                                ApiRepository.User = null;

                                logger.LogInfo($"LogoutAndRemoveSessionToken -> Session Token removed.");

                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                await ApiRepository.IsConnected(logger);
                logger.LogError($"LogoutAndRemoveSessionToken -> {ex.Message}");
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
