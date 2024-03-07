using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class LoginResponseModel
    {
        private bool success;
        private string message;
        private string sessionToken;
        private UserModel user;

        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
        public string SessionToken { get => sessionToken; set => sessionToken = value; }
        public UserModel User { get => user; set => user = value; }
    }
}
