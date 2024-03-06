using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class ClientModel
    {
        // Fields
        private string clientCode;
        private string clientName;

        // Properties
        public string ClientCode { get => clientCode; set => clientCode = value; }
        public string ClientName { get => clientName; set => clientName = value; }

    }
}
