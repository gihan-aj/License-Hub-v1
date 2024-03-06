using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public interface ILicenseRequestRepository
    {
        void Request(LicenseRequestModel licenseRequest);
        IEnumerable<ClientModel> GetClients();
        IEnumerable<PackageModel> GetPackages();
        string GetPCName();
        string GetRequestKey();
    }
}
