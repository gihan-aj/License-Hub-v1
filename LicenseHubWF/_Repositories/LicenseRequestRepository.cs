using LicenseHubWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public class LicenseRequestRepository : BaseRepository, ILicenseRequestRepository
    {
        // Constructor
        public LicenseRequestRepository(string sessionToken) 
        {
            this.sessionToken = sessionToken;
        }

        // Methods
        public IEnumerable<ClientModel> GetClients()
        {
            var clientList = new List<ClientModel>();

            var client01 = new ClientModel() { ClientCode = "C1", ClientName = "Client 01" };
            var client02 = new ClientModel() { ClientCode = "C2", ClientName = "Client 02" };
            var client03 = new ClientModel() { ClientCode = "C3", ClientName = "Client 03" };
            clientList.Add(client01);
            clientList.Add(client02);
            clientList.Add(client03);

            return clientList;

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
