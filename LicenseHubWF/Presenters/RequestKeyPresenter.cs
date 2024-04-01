using LicenseHubWF._Repositories;
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
    public class RequestKeyPresenter
    {
        private IRequestKeyView _view;
        private ILicenseRequestRepository _licenseRequestRepository;
        private ILogger _logger;

        public RequestKeyPresenter(IRequestKeyView view, ILicenseRequestRepository licenseRequestRepository, ILogger logger)
        {
            _view = view;
            _licenseRequestRepository = licenseRequestRepository;
            _logger = logger;

            _view.ShowRequestKey += GetRequestKey;
            
        }

        private void GetRequestKey(object? sender, EventArgs e)
        {
            try
            {
                _view.Key = BaseRepository.RequestKey;

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetRequestKey -> {ex.Message}");
                _logger.LogError($"GetRequestKey -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();

            }
        }
    }
}
