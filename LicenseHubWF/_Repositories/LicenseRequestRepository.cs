using LicenseHubWF.Models;
using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public class LicenseRequestRepository : BaseRepository, ILicenseRequestRepository
    {
        // Fields
        private IFileLogger _logger;

        // Constructor
        public LicenseRequestRepository(string sessionToken, IFileLogger logger) 
        {
            this.sessionToken = sessionToken;
            _logger = logger;
        }

        // Methods
        public async Task<IEnumerable<ClientModel>> GetClients()
        {
            
            using (HttpResponseMessage response =  await ApiRepository.ApiClient.GetAsync("clients"))
            {
                _logger.LogInfo($"GetClients -> {response.RequestMessage}");

                if (response.IsSuccessStatusCode)
                {
                    List<ClientModel> clientList = await response.Content.ReadAsAsync<List<ClientModel>>();

                    return clientList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public IEnumerable<PackageModel> GetPackages()
        {
            var packageList = new List<PackageModel>
                {
                    new PackageModel() { PackageCode = "P1", PackageName = "Package 01" },
                    new PackageModel() { PackageCode = "P2", PackageName = "Package 02" },
                    new PackageModel() { PackageCode = "P3", PackageName = "Package 03" },
                    new PackageModel() { PackageCode = "P4", PackageName = "Package 04" }
                };

            return packageList;

        }

        public string GetRequestKey()
        {

            return "1234567";
       
        }

        public string GetPCName()
        {

            return Environment.MachineName;
     
        }

        public void Request(LicenseRequestModel licenseRequest)
        {
         
        }
    }
}
