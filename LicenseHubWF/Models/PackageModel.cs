using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class PackageModel
    {
        // Fields
        private string packageCode;
        private string packageName;
        private string description;

        // Properties
        public string PackageCode { get => packageCode; set => packageCode = value; }
        public string PackageName { get => packageName; set => packageName = value; }
        public string Description { get => description; set => description = value; }
    }
}
