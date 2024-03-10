using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public interface ILicenseViewRepository
    {
        string BrowseForLicense();
        LicenseModel ReadLicenseFile(string filePath);
        //Task<LicenseModel> ValidateLicense();
    }
}
