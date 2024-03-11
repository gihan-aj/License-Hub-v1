using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Models
{
    public class AppSettingsModel
    {
        private string _apiBaseUrl = "https://9je93.wiremockapi.cloud/api/";
        private string _dateFormat = "yyyy-MM-dd";
        private string _messageBoxTitleConfirmation = "Are you sure ?";
        private string _messageBoxTitleInfo = "Information";
        private string _messageBoxTitleError = "Error";
        private string _licenseFilePath = AppDomain.CurrentDomain.BaseDirectory;
        private string _licenseValid = "This license is valid";
        private string _licenseInvalid = "This license is invalid";
        private string _logoutConfirmationMessage = "Are you sure you want to logout?";

        public string ApiBaseUrl { get => _apiBaseUrl; set => _apiBaseUrl = value; }
        public string DateFormat { get => _dateFormat; set => _dateFormat = value; }
        public string LicenseFilePath { get => _licenseFilePath; set => _licenseFilePath = value; }
        public string LicenseValid { get => _licenseValid; set => _licenseValid = value; }
        public string LicenseInvalid { get => _licenseInvalid; set => _licenseInvalid = value; }
        public string LogoutConfirmationMessage { get => _logoutConfirmationMessage; set => _logoutConfirmationMessage = value; }
        public string MessageBoxTitleConfirmation { get => _messageBoxTitleConfirmation; set => _messageBoxTitleConfirmation = value; }
        public string MessageBoxTitleInfo { get => _messageBoxTitleInfo; set => _messageBoxTitleInfo = value; }
        public string MessageBoxTitleError { get => _messageBoxTitleError; set => _messageBoxTitleError = value; }
    }
}
