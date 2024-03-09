using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public interface IMainRepository
    {
        Task<LogoutModel> Logout();
    }
}
