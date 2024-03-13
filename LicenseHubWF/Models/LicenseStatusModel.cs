using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class LicenseStatusModel
    {
        public bool IsAvailable { get; set; }
        public string? Message { get; set; } 
        public string? RequestId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public LicenseModel? License { get; set; }
    }
}
