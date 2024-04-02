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
        Task<IEnumerable<ClientModel>> GetClients();
        Task<IEnumerable<PackageModel>> GetPackages();
        void VisitLicenseAgreement();
    }
}
