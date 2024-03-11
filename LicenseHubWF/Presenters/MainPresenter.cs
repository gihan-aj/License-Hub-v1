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
            this.mainView.ShowLicenseView += ShowLicense;
            this.mainView.ShowRequestLicenseView += ShowRequestLicenseView;
            this.mainView.ShowLoginView += ShowLoginView;
            this.mainView.LogoutEvent += LogoutAndRemoveSessionToken;

            logger = new FileLogger();
            baseUrl = ApiRepository.GetSetting<string>("ApiBaseUrl");
           
            if(baseUrl != null)
            {
                ApiRepository.InitializeClient(baseUrl);
                ApiRepository.IsConnected(logger);
            }

            // License view


            // License request


        }

        private void ShowLicense(object? sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Dispose();
            }

            ILicenseView licenseView = new LicenseView();
            ILicenseViewRepository licenseViewRepository = new LicenseViewRepository(logger);
            new LicenseViewPresenter(licenseView, licenseViewRepository, logger);

            activeForm = (Form)licenseView;
            mainView.OpenChildForm((Form)licenseView);
        }

        private void ShowRequestLicenseView(object? sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Dispose();
            }

            ILicenseRequestView licenseRequestView = new LicenseRequestView();
            ILicenseRequestRepository licenseRequestRepository = new LicenseRequestRepository(logger);
            new LicenseRequestPresenter(licenseRequestView, licenseRequestRepository, logger);

            activeForm = (Form)licenseRequestView;
            mainView.OpenChildForm((Form)licenseRequestView);
        }

        private async void LogoutAndRemoveSessionToken(object? sender, EventArgs e)
        {
            try
            {

                IMessageBoxView confirmView = new MessageBoxView();
                confirmView.Title = "Confirmation";
                confirmView.Message = ApiRepository.GetSetting<string>("LogoutConfirmationMessage");
                confirmView.Show();

                confirmView.ClickEvent += async delegate
                {
                    if (confirmView.IsAccepted)
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

                                IMessageBoxView confirmView = new MessageBoxView()
                                {
                                    Title = "Info",
                                    Message = ApiRepository.GetSetting<string>("LogoutSuccessMessage")
                                };
                                confirmView.Show();

                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
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


    }
}
