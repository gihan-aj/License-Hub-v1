using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class LicenseModel
    {
        public required string LicenseId { get; set; }
        public required string Client { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string PcName { get; set; }
        public required string RequestId { get; set; }
        public required string[] PackageList { get; set; }
    }
}
