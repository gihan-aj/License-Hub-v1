using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class UserModel
    {
        private string name;
        private string email;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
    }
}
