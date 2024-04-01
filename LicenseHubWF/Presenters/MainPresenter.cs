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
using static LicenseHubWF.Models.AppServiceModel;

namespace LicenseHubWF.Presenters
{
    public class MainPresenter
    {
        private IMainView _mainView;
        private IMainRepository _mainRepository;
        private Form? _activeForm;
        private IFileLogger _logger;

        public MainPresenter(IMainView mainView, IMainRepository mainRepository, IFileLogger logger)
        {
            _mainView = mainView;
            _mainRepository = mainRepository;
            _logger = logger;

            _ = BaseRepository.EstablishConnection(_logger);

            // Events
            _mainView.ShowLicenseView += ShowLicense;
            _mainView.ShowRequestLicenseView += ShowRequestLicenseView;
            _mainView.ShowDownloadLicenseView += ShowDownloadLicenseView;
            _mainView.ShowRequestKeyView += ShowRequestKey;
            _mainView.ShowConfigurationView += ShowConfiguration;
            _mainView.ShowLoginView += ShowLoginView;
            _mainView.LogoutEvent += LogoutAndRemoveSessionToken;

            BaseRepository.ConnectivityChanged += _mainView.OnConnectivityChanged;
            BaseRepository.UserChanged += _mainView.OnUserChanged;

        }

        //private async void SetUpConnection(IFileLogger logger)
        //{
        //    try
        //    {
        //        await ApiRepository.IsConnected(logger);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"SetUpConnection -> {ex.Message}");
        //        logger.LogError($"SetUpConnection -> Exception: {ex}");

        //        IMessageBoxView messageBox = new MessageBoxView()
        //        {
        //            Title = "Error",
        //            Message = ex.Message
        //        };
        //        messageBox.Show();
        //    }
        //}

        private void ShowLicense(object? sender, EventArgs e)
        {
            try
            {
                if (_activeForm != null)
                {
                    _activeForm.Dispose();
                }

                ILicenseView licenseView = new LicenseView();
                ILicenseViewRepository licenseViewRepository = new LicenseViewRepository(_logger);
                new LicenseViewPresenter(licenseView, licenseViewRepository, _logger);

                _activeForm = (Form)licenseView;
                _mainView.OpenChildForm((Form)licenseView);
                _mainView.CurrentPageName = "License";
            }
            catch (Exception ex)
            {

                _logger.LogError($"ShowLicense -> {ex.Message}");
                _logger.LogError($"ShowLicense -> Exception: {ex}");

                BaseRepository.ShowMessage("Error", ex.Message );
            }

        }

        //private async void VerifyAndShowRequestLicenseView(object? sender, EventArgs e)
        //{
        //    try
        //    {
        //        TokenVerificationModel tokenVerification = await ApiRepository.VerifyToken(_logger);
        //        if (tokenVerification.Success == false)
        //        {
        //            ILoginView loginView = new LoginView();
        //            ILoginRepository loginRepository = new LoginRepository(_logger);
        //            new LoginPresenter(loginView, loginRepository, _logger);

        //            ApiRepository.SessionTokenChanged += delegate
        //            {
        //                ShowRequestLicenseView();
        //            };
        //        }
        //        else
        //        {
        //            ShowRequestLicenseView();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"ShowRequestLicenseView -> {ex.Message}");
        //        _logger.LogError($"ShowRequestLicenseView -> Exception: {ex}");

        //        IMessageBoxView messageBox = new MessageBoxView()
        //        {
        //            Title = "Error",
        //            Message = ex.Message
        //        };
        //        messageBox.Show();
        //    }

        //}

        private void ShowRequestLicenseView(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ApiRepository.SessionToken))
            {
                if (_activeForm != null)
                {
                    _activeForm.Dispose();
                }

                ILicenseRequestView licenseRequestView = new LicenseRequestView();
                ILicenseRequestRepository licenseRequestRepository = new LicenseRequestRepository(_logger);
                new LicenseRequestPresenter(licenseRequestView, licenseRequestRepository, _logger);

                _activeForm = (Form)licenseRequestView;
                _mainView.OpenChildForm((Form)licenseRequestView);
                _mainView.CurrentPageName = "License Request";
            }
        }

        //private async void VerifyAndShowDownloadLicenseView(object? sender, EventArgs e)
        //{
        //    try
        //    {
        //        TokenVerificationModel tokenVerification = await ApiRepository.VerifyToken(_logger);
        //        if (tokenVerification.Success == false)
        //        {
        //            ILoginView loginView = new LoginView();
        //            ILoginRepository loginRepository = new LoginRepository(_logger);
        //            new LoginPresenter(loginView, loginRepository, _logger);

        //            ApiRepository.SessionTokenChanged += delegate
        //            {
        //                ShowDownloadLicenseView();
        //            };
        //        }
        //        else
        //        {
        //            ShowDownloadLicenseView();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"ShowRequestLicenseView -> {ex.Message}");
        //        _logger.LogError($"ShowRequestLicenseView -> Exception: {ex}");

        //        IMessageBoxView messageBox = new MessageBoxView()
        //        {
        //            Title = "Error",
        //            Message = ex.Message
        //        };
        //        messageBox.Show();
        //    }

        //}

        private void ShowDownloadLicenseView(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ApiRepository.SessionToken))
            {
                if (_activeForm != null)
                {
                    _activeForm.Dispose();
                }

                ILicenseDownloadView view = new LicenseDownloadView();
                ILicenseDownloadRepository repository = new LicenseDownloadRepository(_logger);
                new LicenseDownloadPresenter(view, repository, _logger);

                _activeForm = (Form)view;
                _mainView.OpenChildForm((Form)view);
                _mainView.CurrentPageName = "License Download";
            }
        }

        private void ShowRequestKey(object? sender, EventArgs e)
        {
            try
            {
                IRequestKeyView requestKeyView = new RequestKeyView();
                ILicenseRequestRepository requestKeyRepository = new LicenseRequestRepository(_logger);
                new RequestKeyPresenter(requestKeyView, requestKeyRepository, _logger);

                _mainView.OpenChildForm((Form)requestKeyView);
                _mainView.CurrentPageName = "Request Key";
            }
            catch (Exception ex)
            {

                _logger.LogError($"ShowRequestKey -> {ex.Message}");
                _logger.LogError($"ShowRequestKey -> Exception: {ex}");

                BaseRepository.ShowMessage("Error", ex.Message);
            }

        }

        private void ShowConfiguration(object? sender, EventArgs e)
        {
            try
            {
                if (_activeForm != null)
                {
                    _activeForm.Dispose();
                }

                IConfigurationView configurationView = new ConfigurationView();
                new ConfigurationPresenter(configurationView, _logger);

                _activeForm = (Form)configurationView;
                _mainView.OpenChildForm((Form)configurationView);
                _mainView.CurrentPageName = "Configuration";
            }
            catch (Exception ex)
            {
                _logger.LogError($"ShowConfiguration -> {ex.Message}");
                _logger.LogError($"ShowConfiguration -> Exception: {ex}");

                BaseRepository.ShowMessage("Error", ex.Message);
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
                        LogoutResponse logoutResponses = await _mainRepository.Logout();

                        _logger.LogInfo($"LogoutAndRemoveSessionToken -> {logoutResponses.message}");

                        if (logoutResponses != null)
                        {
                            if (logoutResponses.flag)
                            {
                                BaseRepository.SessionToken = null;
                                BaseRepository.User = null;

                                _mainView.RemoveChildForm(null, EventArgs.Empty);

                                _logger.LogInfo($"LogoutAndRemoveSessionToken -> Session Token removed.");

                                BaseRepository.ShowMessage("Info", ApiRepository.GetSetting<string>("LogoutSuccessMessage"));

                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"LogoutAndRemoveSessionToken -> {ex.Message}");
                _logger.LogError($"LogoutAndRemoveSessionToken -> Exception : {ex}");

                BaseRepository.ShowMessage("Error", ex.Message);

                await BaseRepository.EstablishConnection(_logger);
                
            }
        }

        private void ShowLoginView(object? sender, EventArgs e)
        {
            ILoginRepository loginRepository = new LoginRepository(_logger);
            new LoginPresenter(loginRepository, _logger);
        }


    }
}
