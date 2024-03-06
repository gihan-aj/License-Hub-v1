using LicenseHubWF.Views;
using LicenseHubWF.Models;
using LicenseHubWF.Presenters;
using LicenseHubWF._Repositories;
using LoggerLib;

namespace LicenseHubWF
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IMainView view = new MainView();
            new MainPresenter(view);
            Application.Run((Form)view);
        }
    }
}