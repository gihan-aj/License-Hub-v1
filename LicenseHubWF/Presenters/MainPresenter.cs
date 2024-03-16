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
        private IMainView _mainView;
        private IMainRepository _mainRepository;
        private Form? activeForm;
        private IFileLogger _logger;

        public MainPresenter(IMainView mainView, IMainRepository mainRepository, IFileLogger logger)
        {
            this._mainView = mainView;
            this._mainRepository = mainRepository;
            this._logger = logger;

            

            // Events
            this._mainView.ShowLicenseView += ShowLicense;
            this._mainView.ShowRequestLicenseView += VerifyAndShowRequestLicenseView;
            this._mainView.ShowRequestKeyView += ShowRequestKey;
            this._mainView.ShowConfigurationView += ShowConfiguration;
            this._mainView.ShowLoginView += ShowLoginView;
            this._mainView.LogoutEvent += LogoutAndRemoveSessionToken;

            ApiRepository.VerificationFailed += ShowLoginView;

            SetUpConnection(logger);

        }

        private async void SetUpConnection(IFileLogger logger)
        {
            try
            {
                await ApiRepository.IsConnected(logger);
            }
            catch (Exception ex)
            {
                logger.LogError($"SetUpConnection -> {ex.Message}");
                logger.LogError($"SetUpConnection -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }
        }

        private void ShowLicense(object? sender, EventArgs e)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Dispose();
                }

                ILicenseView licenseView = new LicenseView();
                ILicenseViewRepository licenseViewRepository = new LicenseViewRepository(_logger);
                new LicenseViewPresenter(licenseView, licenseViewRepository, _logger);

                activeForm = (Form)licenseView;
                _mainView.OpenChildForm((Form)licenseView);
                _mainView.CurrentPageName = "License";
            }
            catch (Exception ex)
            {

                _logger.LogError($"ShowLicense -> {ex.Message}");
                _logger.LogError($"ShowLicense -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }

        }

        private async void VerifyAndShowRequestLicenseView(object? sender, EventArgs e)
        {
            try
            {
                TokenVerificationModel tokenVerification = await ApiRepository.VerifyToken(_logger);
                if (tokenVerification.Success == false)
                {
                    ILoginView loginView = new LoginView();
                    ILoginRepository loginRepository = new LoginRepository(_logger);
                    new LoginPresenter(loginView, loginRepository, _logger);

                    ApiRepository.SessionTokenChanged += delegate
                    {
                        ShowRequestLicenseView();
                    };
                }
                else
                {
                    ShowRequestLicenseView();
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"ShowRequestLicenseView -> {ex.Message}");
                _logger.LogError($"ShowRequestLicenseView -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }

        }

        private void ShowRequestLicenseView()
        {
            if (!string.IsNullOrEmpty(ApiRepository.SessionToken))
            {
                if (activeForm != null)
                {
                    activeForm.Dispose();
                }

                ILicenseRequestView licenseRequestView = new LicenseRequestView();
                ILicenseRequestRepository licenseRequestRepository = new LicenseRequestRepository(_logger);
                new LicenseRequestPresenter(licenseRequestView, licenseRequestRepository, _logger);

                activeForm = (Form)licenseRequestView;
                _mainView.OpenChildForm((Form)licenseRequestView);
                _mainView.CurrentPageName = "License Request";
            }
        }

        private void ShowRequestKey(object? sender, EventArgs e)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Dispose();
                }

                IRequestKeyView requestKeyView = new RequestKeyView();
                ILicenseRequestRepository requestKeyRepository = new LicenseRequestRepository(_logger);
                new RequestKeyPresenter(requestKeyView, requestKeyRepository, _logger);

                activeForm = (Form)requestKeyView;
                _mainView.OpenChildForm((Form)requestKeyView);
                _mainView.CurrentPageName = "Request Key";
            }
            catch (Exception ex)
            {

                _logger.LogError($"ShowRequestKey -> {ex.Message}");
                _logger.LogError($"ShowRequestKey -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }

        }

        private void ShowConfiguration(object? sender, EventArgs e)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Dispose();
                }

                IConfigurationView configurationView = new ConfigurationView();
                new ConfigurationPresenter(configurationView, _logger);

                activeForm = (Form)configurationView;
                _mainView.OpenChildForm((Form)configurationView);
                _mainView.CurrentPageName = "Configuration";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ShowConfiguration -> {ex.Message}");
                _logger.LogError($"ShowConfiguration -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }
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
                        LogoutModel logoutDetails = await _mainRepository.Logout();

                        _logger.LogInfo($"LogoutAndRemoveSessionToken -> {logoutDetails.Message}");

                        if (logoutDetails != null)
                        {
                            if (logoutDetails.Success)
                            {
                                ApiRepository.SessionToken = null;
                                ApiRepository.User = null;

                                _logger.LogInfo($"LogoutAndRemoveSessionToken -> Session Token removed.");

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
                await ApiRepository.IsConnected(_logger);
                _logger.LogError($"LogoutAndRemoveSessionToken -> {ex.Message}");
            }
        }

        private void ShowLoginView(object? sender, EventArgs e)
        {
            ILoginView loginView = new LoginView();
            ILoginRepository loginRepository = new LoginRepository(_logger);
            new LoginPresenter(loginView, loginRepository, _logger);
        }


    }
}
