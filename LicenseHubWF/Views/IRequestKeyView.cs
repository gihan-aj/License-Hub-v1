using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IRequestKeyView
    {
        string Key { set;}

        event EventHandler ShowRequestKey;

    }
}
