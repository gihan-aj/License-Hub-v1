using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public interface ILoginRepository
    {
        public event EventHandler LoginSuccessfull;
        public event EventHandler LoginFailed;
        Task<LoginResponseModel> Login(LoginModel loginDetails);
        
    }
}
