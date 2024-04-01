using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicenseHubWF.Models.AppServiceModel;

namespace LicenseHubWF.Models
{
    public interface IMainRepository
    {
        Task<LogoutResponse> Logout();
    }
}
