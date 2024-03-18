using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;

namespace LicenseHubWF.Presenters
{
    public class LicenseRequestPresenter
    {
        // Fields
        private ILicenseRequestView view;
        private ILicenseRequestRepository repository;
        private IEnumerable<ClientModel> clientList;
        private IEnumerable<PackageModel> packageList;
        private IFileLogger _logger;

        public LicenseRequestPresenter(ILicenseRequestView view, ILicenseRequestRepository repository, IFileLogger logger)
        {
            this.view = view;
            this.repository = repository;

            // text logger
            _logger = logger;

            // Subscribe event handler methods to view events
            this.view.RequestLicenseEvent += RequestLicense;
            this.view.LicenseAgreementEvent += ShowLicenseAgreement;

            // Set binding sources
            // ...

            // Load data to view
            LoadRequestKey();
            LoadPCName();
            LoadClients();
            LoadPackages();

            // Show view
            //this.view.Show();
        }

        private void ShowLicenseAgreement(object? sender, EventArgs e)
        {
            try
            {
                repository.VisitLicenseAgreement();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ShowLicenseAgreement -> {ex.Message}");
                _logger.LogError($"ShowLicenseAgreement -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
            }
        }

        // Methods
        private async void LoadClients()
        {
            try
            {
                clientList = await repository.GetClients();
                view.SetClientList(clientList);

                _logger.LogInfo($"LoadClients -> Client list loaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoadClients -> {ex.Message}");
                _logger.LogError($"LoadClients -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
            }

        }

        private async void LoadPackages()
        {
            try
            {
                packageList = await repository.GetPackages();
                view.SetPackageList(packageList);

                _logger.LogInfo($"LoadPackages -> Package list loaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoadPackages -> {ex.Message}");
                _logger.LogError($"LoadPackages -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
            }

        }

        private void LoadPCName()
        {
            try
            {
                view.PCName = repository.GetPCName();

                _logger.LogInfo($"LoadPCName -> PC name loaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoadPCName -> {ex.Message}");
                _logger.LogError($"LoadPCName -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
            }
        }

        private void LoadRequestKey()
        {
            try
            {
                view.RequestKey = repository.GetRequestKey();

                _logger.LogInfo($"LoadRequestKey -> Request key loaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoadRequestKey -> {ex.Message}");
                _logger.LogError($"LoadRequestKey -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
            }

        }

        private void RequestLicense(object? sender, EventArgs e)
        {
            try
            {
                _logger.LogInfo($"RequestLicense -> License requested.");
                if (view.IsAgreementAccepted)
                {
                    if (string.IsNullOrEmpty(view.Client))
                    {
                        throw new Exception("Client must be selected.");
                    }
                    if (string.IsNullOrEmpty(view.LicenseType))
                    {
                        throw new Exception("License type must be selected.");
                    }
                    if (view.Packages.Count == 0)
                    {
                        throw new Exception("Select required packages.");
                    }

                    LicenseRequestModel licenseRequest = new LicenseRequestModel()
                    {
                        Client = view.Client,
                        LicenseType = view.LicenseType,
                        PcName = view.PCName,
                        RequestKey = view.RequestKey,
                        Packages = view.Packages
                    };

                    //new Common.ModelDataValidation().Validate( licenseRequest );

                }
                else
                {
                    throw new Exception("License agreement must be accepted");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"RequestLicense -> {ex.Message}");
                _logger.LogError($"RequestLicense -> Exception : {ex}");

                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();

            }
            

        }
    }
}
