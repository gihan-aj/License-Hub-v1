using LicenseHubWF._Repositories;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Presenters
{
    public class LicenseViewPresenter
    {
        private ILicenseView _view;
        private ILicenseViewRepository _repository;
        private readonly IFileLogger _logger;

        public LicenseViewPresenter(ILicenseView view, ILicenseViewRepository repository, IFileLogger logger)
        {
            _view = view;
            _repository = repository;
            _logger = logger;

            view.LoadLicenseEvent += LoadLicenseFile;
            view.BrowseEvent += BrowseLicenseFile;
        }

        private void LoadLicenseFile(object? sender, EventArgs e)
        {
            try
            {
                var filePath = BaseRepository.GetSetting<string>("LicenseFilePath");
                if (File.Exists(filePath))
                {
                    _view.License = _repository.ReadLicenseFile(filePath);
                    _view.FilePath = filePath;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoadLicenseFile -> {ex.Message}");
                _logger.LogError($"LoadLicenseFile -> Exception : {ex}");
                BaseRepository.ShowMessage("Error", ex.Message);
            }
        }

        private void BrowseLicenseFile(object? sender, EventArgs e)
        {
            try
            {
                string filepath = _repository.BrowseForLicense();
                if (!string.IsNullOrEmpty(filepath))
                {
                    _view.FilePath = filepath;
                    LicenseModel license = _repository.ReadLicenseFile(filepath);
                    if (license != null)
                    {
                        _view.License = license;

                        BaseRepository.UpdateAppSettings("LicenseFilePath",filepath,_logger);

                        _logger.LogInfo($"BrowseLicenseFile -> License loaded.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"BrowseLicenseFile -> {ex.Message}");
                _logger.LogError($"BrowseLicenseFile -> Exception : {ex}");
                BaseRepository.ShowMessage("Error", ex.Message);
            }

        }
    }
}
