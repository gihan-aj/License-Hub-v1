using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IMessageBoxView
    {
        string Title { set; }
        string Message { set; }
        bool IsAccepted { get;  }

        event EventHandler ClickEvent;

        void Show();
        void Close();
    }
}
