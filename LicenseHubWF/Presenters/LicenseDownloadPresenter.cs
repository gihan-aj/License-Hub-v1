using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Presenters
{
    public class LicenseDownloadPresenter
    {
        private ILicenseDownloadView _view;
        private ILicenseDownloadRepository _repository;
        private IFileLogger _logger;

        public LicenseDownloadPresenter(ILicenseDownloadView view, ILicenseDownloadRepository repository, IFileLogger logger)
        {
            _view = view;
            _repository = repository;
            _logger = logger;

            _view.CheckStatusEvent += CheckStatus;
            _view.DownloadLicenseEvent += DownloadLicense;
        }

        private void DownloadLicense(object? sender, EventArgs e)
        {
            
        }

        private void CheckStatus(object? sender, EventArgs e)
        {
            
        }
    }
}
