using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Views
{
    public interface IConfigurationView
    {
        string BaseAdsress { get; }
        string TestMessage { set; }
        bool IsSaved { set; }

        event EventHandler TestEvent;
        event EventHandler SaveEvent;

        void Show();
        void Dispose();
    }
}
