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
        private IFileLogger logger;

        public LicenseRequestPresenter(ILicenseRequestView view, ILicenseRequestRepository repository)
        {
            this.view = view;
            this.repository = repository;

            // text logger
            this.logger = new FileLogger();

            // Subscribe event handler methods to view events
            this.view.RequestLicenseEvent += RequestLicense; 

            // Set binding sources
            // ...

            // Load data to view
            LoadClients();
            LoadRequestKey();
            LoadPCName();
            LoadPackages();

            // Show view
            this.view.Show();
        }

        // Methods
        private void LoadClients()
        {
            try
            {
                clientList = repository.GetClients();
                view.SetClientList(clientList);

                logger.LogInfo($"LoadClients -> Client list loaded.");
            }
            catch (Exception ex)
            {
                logger.LogError($"LoadClients -> {ex.Message}");
            }
       
        }

        private void LoadPackages()
        {
            try
            {
                packageList = repository.GetPackages();
                view.SetPackageList(packageList);

                logger.LogInfo($"LoadPackages -> Package list loaded.");
            }
            catch (Exception ex)
            {
                logger.LogError($"LoadPackages -> {ex.Message}");
            }

        }

        private void LoadPCName()
        {
            try
            {
                view.PCName = repository.GetPCName();

                logger.LogInfo($"LoadPCName -> PC name loaded.");
            }
            catch (Exception ex)
            {
                logger.LogError($"LoadPCName -> {ex.Message}");
            }
        }

        private void LoadRequestKey()
        {
            try
            {
                view.RequestKey = repository.GetRequestKey();

                logger.LogInfo($"LoadRequestKey -> Request key loaded.");
            }
            catch (Exception ex)
            {
                logger.LogError($"LoadRequestKey -> {ex.Message}");
            }

        }

        private void RequestLicense(object? sender, EventArgs e)
        {
            try
            {
                logger.LogInfo($"RequestLicense -> License requested.");
            }
            catch (Exception ex)
            {
                logger.LogError($"RequestLicense -> {ex.Message}");
            }
            

        }
    }
}
