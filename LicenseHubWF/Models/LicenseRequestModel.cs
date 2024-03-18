using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LicenseHubWF.Models
{
    public class LicenseRequestModel
    {
        //Fields
        private string sessionToken;
        private string requestKey;
        private string client;
        private string licenseType;
        private string pcName;
        private List<string> packages;

        // Properties

        public string SessionToken { get => sessionToken; set => sessionToken = value; }

        public string RequestKey { get => requestKey; set => requestKey = value; }

        //[Required(ErrorMessage ="The client should be selected.")]
        public string Client { get => client; set => client = value; }

        //[Required(ErrorMessage = "Select the license type.")]
        public string LicenseType { get => licenseType; set => licenseType = value; }

        public string PcName { get => pcName; set => pcName = value; }

        //[Required(ErrorMessage = "Select requesting packages.")]
        public List<string> Packages { get => packages; set => packages = value; }
    }
}
