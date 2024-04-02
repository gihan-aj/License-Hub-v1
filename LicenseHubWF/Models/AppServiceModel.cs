using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class AppServiceModel
    {
        public record class LoginRequest(string userEmail, string password);
        public record class LoginResponse ( bool flag, string message, string token, UserModel user);
        public record class LogoutResponse (bool flag, string message);
        public record class VerificationResponse (bool flag, string message);
    }
}
