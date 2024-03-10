using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public class LicenseViewRepository : ILicenseViewRepository
    {
        private readonly IFileLogger _logger;

        public LicenseViewRepository(IFileLogger logger)
        {
            _logger = logger;
        }

        //public Task<LicenseModel> ValidateLicense()
        //{
        //    return
        //}

        public string BrowseForLicense()
        {

            OpenFileDialog fileBrowser = new OpenFileDialog()
            {
                Title = "Select license file",
                Filter = "json files(*.json)| *.json",
                FilterIndex = 1,
                Multiselect = false,
                RestoreDirectory = true,
            };
            

            if(fileBrowser.ShowDialog() == DialogResult.OK)
            {
                var filePath = fileBrowser.FileName;

                FileInfo fileInfo = new FileInfo(filePath);
                string fullPath = fileInfo.FullName;

                _logger.LogInfo($"BrowseForLicense -> {fullPath}");

                return fullPath;
                
            }
            else
            {
                _logger.LogWarning($"BrowseForLicense -> No file selected");
                return string.Empty;
            }
        }

        public LicenseModel ReadLicenseFile(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                LicenseModel license = JsonConvert.DeserializeObject<LicenseModel>(jsonContent);

                return license;
            }
            catch 
            {
                throw new JsonException();
            }


        }
    }
}
