using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface ILoginView
    {
        public string Email { get; set; }
        public string Password { get; set; }

        event EventHandler LoginEvent;

        void Show();
        void Dispose();
    }
}
