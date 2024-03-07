using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public interface ILoginRepository
    {
        Task<LoginResponseModel> Login(LoginModel loginDetails);
        
    }
}
