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

            IFileLogger logger = new FileLogger();
            logger.LogInfo("_________APP STARTED____________");
            ApiRepository.LoadAppSettingsFile(logger);

            IMainView view = new MainView();
            IMainRepository repository = new MainRepository(logger);
            new MainPresenter(view, repository, logger);

            Application.Run((Form)view);
        }
    }
}