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

        private string _txtReader = "notepad.exe";

        private string _logoutSuccessMessage = "Logout Successfull.";

        private string _licenseValid = "This license is valid";

        private string _licenseInvalid = "This license is invalid";

        private string _licenseAgreementCheckBoxText = "I agree with the terms in the License Agreement.";

        private string _licenseAgreementPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LicenseAgreement.txt");

        private string _logoutConfirmationMessage = "Are you sure you want to logout?";

        private string _requestKeyInfo = "Please contact 'keys.dspcontrols.lk' with this key";

        public string ApiBaseUrl { get => _apiBaseUrl; set => _apiBaseUrl = value; }
        public string DateFormat { get => _dateFormat; set => _dateFormat = value; }
        public string LicenseFilePath { get => _licenseFilePath; set => _licenseFilePath = value; }
        public string LicenseValid { get => _licenseValid; set => _licenseValid = value; }
        public string LicenseInvalid { get => _licenseInvalid; set => _licenseInvalid = value; }
        public string LogoutConfirmationMessage { get => _logoutConfirmationMessage; set => _logoutConfirmationMessage = value; }
        public string MessageBoxTitleConfirmation { get => _messageBoxTitleConfirmation; set => _messageBoxTitleConfirmation = value; }
        public string MessageBoxTitleInfo { get => _messageBoxTitleInfo; set => _messageBoxTitleInfo = value; }
        public string MessageBoxTitleError { get => _messageBoxTitleError; set => _messageBoxTitleError = value; }
        public string LogoutSuccessMessage { get => _logoutSuccessMessage; set => _logoutSuccessMessage = value; }
        public string LicenseAgreementCheckBoxText { get => _licenseAgreementCheckBoxText; set => _licenseAgreementCheckBoxText = value; }
        public string LicenseAgreementPath { get => _licenseAgreementPath; set => _licenseAgreementPath = value; }
        public string TxtReader { get => _txtReader; set => _txtReader = value; }
        public string RequestKeyInfo { get => _requestKeyInfo; set => _requestKeyInfo = value; }
    }
}
