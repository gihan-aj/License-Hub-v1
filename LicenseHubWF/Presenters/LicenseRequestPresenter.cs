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
                IMessageBoxView confirmView = new MessageBoxView();
                confirmView.Title = "Error";
                confirmView.Message = ex.Message;
                confirmView.Show();
                _logger.LogError($"LoadClients -> {ex.Message}");
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
                IMessageBoxView confirmView = new MessageBoxView();
                confirmView.Title = "Error";
                confirmView.Message = ex.Message;
                confirmView.Show();
                _logger.LogError($"LoadPackages -> {ex.Message}");
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
                IMessageBoxView confirmView = new MessageBoxView();
                confirmView.Title = "Error";
                confirmView.Message = ex.Message;
                confirmView.Show();
                _logger.LogError($"LoadPCName -> {ex.Message}");
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
                IMessageBoxView confirmView = new MessageBoxView();
                confirmView.Title = "Error";
                confirmView.Message = ex.Message;
                confirmView.Show();
                _logger.LogError($"LoadRequestKey -> {ex.Message}");
            }

        }

        private void RequestLicense(object? sender, EventArgs e)
        {
            try
            {
                _logger.LogInfo($"RequestLicense -> License requested.");
            }
            catch (Exception ex)
            {
                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();

                _logger.LogError($"RequestLicense -> {ex.Message}");
            }
            

        }
    }
}
