using LicenseHubWF.Models;
using LoggerLib;
using Microsoft.Win32;
using Newtonsoft.Json;
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
        // Fields
        private static UserModel? _user;
        private static bool _connectivity = false;
        private static Dictionary<string, string> _appSettings;

        // Events
        public static event EventHandler UserChanged;
        public static event EventHandler ConnectivityChanged; 

        // Properties
        public static HttpClient? ApiClient { get; set; }
        public static string? SessionToken { get; set; }
        public static UserModel? User 
        { 
            get => _user; 
            set
            {
                _user = value;
                UserChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        public static bool Connectivity 
        {  
            get => _connectivity;

            set
            {
                _connectivity = value;
                ConnectivityChanged?.Invoke(null, EventArgs.Empty);
            } 
        }

        // Methods
        public static void InitializeClient(string baseUrl)
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(baseUrl);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task IsConnected(IFileLogger logger)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "test"))
            {
                using (var response = await ApiClient.SendAsync(request))
                {
                    logger.LogInfo($"IsConnected -> {response.RequestMessage}");

                    if (response.IsSuccessStatusCode)
                    {
                        Connectivity = true;
                        logger.LogInfo($"IsConnected -> Server connection working.");
                    }
                    else
                    {
                        Connectivity = false;
                        logger.LogError($"IsConnected -> {response.ReasonPhrase}");
                    }
                }
            }
        }

        public static string? GetAppSetting(string key)
        {
            return _appSettings.ContainsKey(key) ? _appSettings[key] : null; 
        }

        public static void LoadAppSettings(IFileLogger logger)
        {
            var appSettings = new Dictionary<string, string>();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                var value = ConfigurationManager.AppSettings[key];
                appSettings[key] = value;
                logger.LogInfo($"LoadAppSettings -> {key} : {value}");
            }

            _appSettings = appSettings;
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
