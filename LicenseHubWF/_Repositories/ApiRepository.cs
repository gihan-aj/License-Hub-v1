using LicenseHubWF.Models;
using LoggerLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public static class ApiRepository
    {
        // Events
        private static event EventHandler UserChanged;

        // Properties
        public static HttpClient? ApiClient { get; set; }
        public static string? SessionToken { get; set; }
        public static UserModel? User { get; set; }
        public static bool Connectivity {  get; set; } = false;

        // Methods
        public static void InitializeClient(string baseUrl)
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(baseUrl);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string? GetAPIBaseUrl(IFileLogger logger)
        {
            string? apiBaseUrl; 

            if (ConfigurationManager.AppSettings.AllKeys.Contains("ApiBaseUrl"))
            {
                apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
                logger.LogInfo($"GetAPIBaseUrl -> {apiBaseUrl}");
            }
            else
            {
                apiBaseUrl = null;
                logger.LogError($"GetAPIBaseUrl -> Server Address is missing in the configuration.");
            }

            return apiBaseUrl;
        }

    }
}
