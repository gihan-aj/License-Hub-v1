using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public static class ApiRepository
    {
        // Fields
        private static UserModel? _user;
        private static string _sessionToken = string.Empty;
        private static bool _connectivity = false;
        private static AppSettingsModel _settings = new AppSettingsModel();
        private static string _appSetttingsPath = string.Empty;

        // Delegates
        public delegate void VerificationFailedEventHandler(object? sender, EventArgs e);

        // Events
        public static event EventHandler UserChanged;
        public static event EventHandler ConnectivityChanged; 
        public static event EventHandler SessionTokenChanged;
        public static event VerificationFailedEventHandler VerificationFailed;

        // Properties

        public static HttpClient? ApiClient { get; set; }
        public static string SessionToken
        {
            get => _sessionToken;
            set 
            {
                _sessionToken = value;
                SessionTokenChanged?.Invoke(null, EventArgs.Empty);
            }
        }
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
        public static void LoadAppSettingsFile(IFileLogger logger)
        {
            try
            {
                //string path = @".\AppSettings.json";
                _appSetttingsPath = Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.json");
                if (!File.Exists(_appSetttingsPath))
                {
                    var initialSettings = new AppSettingsModel();

                    SaveAppSettings(initialSettings);

                    logger.LogInfo($"CreateAndReadAppSettingsFile -> App settings created.");
                }
                else
                {
                    string jsonContent = File.ReadAllText(_appSetttingsPath);
                    _settings = JsonConvert.DeserializeObject<AppSettingsModel>(jsonContent);
                    logger.LogInfo($"CreateAndReadAppSettingsFile -> App settings loaded.");
                }
            }
            catch (JsonException ex)
            {
                logger.LogError($"CreateAndReadAppSettingsFile -> {ex.Message}");
            }

        }

        public static void UpdateAppSettings(string property, string value, IFileLogger logger)
        {
            try
            {
                PropertyInfo propertyInfo = _settings.GetType().GetProperty(property);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(_settings, value);
                }
                else
                {
                    logger.LogError($"UpdateAppSettings -> Property ({property}) not found or is read-only");
                }

                SaveAppSettings(_settings);

                
            }
            catch(Exception ex)
            {
                logger.LogError($"UpdateAppSettings -> Property ({property}) : {ex.Message}");
            }
        }

        public static T GetSetting<T>(string property)
        {
            try
            {
                PropertyInfo propertyInfo = _settings.GetType().GetProperty(property);
                if (propertyInfo != null && propertyInfo.CanRead)
                {
                    return (T)propertyInfo.GetValue(_settings);
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                throw;
            }
        }

        private static void SaveAppSettings(AppSettingsModel settings)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonString = JsonConvert.SerializeObject(settings, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            });

            File.WriteAllText(_appSetttingsPath, jsonString);
        }

        // Initiate HttpClient at the start
        public static void InitializeClient(string baseUrl)
        {
            try
            {
                if(baseUrl != null)
                {
                    ApiClient = new HttpClient();
                    ApiClient.BaseAddress = new Uri(baseUrl);
                    ApiClient.DefaultRequestHeaders.Accept.Clear();
                    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                else
                {
                    throw new Exception("Base url not found.");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static async Task IsConnected(IFileLogger logger)
        {
            try
            {
                string baseUrl = GetSetting<string>("ApiBaseUrl");
                Connectivity = false;

                if(ApiClient != null)
                {
                    if (baseUrl != null)
                    {
                        InitializeClient(baseUrl);

                        using (var request = new HttpRequestMessage(HttpMethod.Get, "test"))
                        {
                            using (var response = await ApiClient.SendAsync(request))
                            {
                                logger.LogInfo($"IsConnected -> {response.RequestMessage}");

                                if (response.IsSuccessStatusCode)
                                {
                                    TestModel testResponse = await response.Content.ReadAsAsync<TestModel>();
                                    if (!string.IsNullOrEmpty(testResponse.Message))
                                    {
                                        Connectivity = true;
                                        logger.LogInfo($"IsConnected -> Server connection working.");
                                    }
                                    else
                                    {
                                        Connectivity = false;
                                        logger.LogError($"IsConnected -> Incorrect url");
                                    }

                                }
                                else
                                {
                                    Connectivity = false;
                                    logger.LogError($"IsConnected -> {response.ReasonPhrase}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Connectivity = false;
                        throw new Exception("Base url not found.");
                    }
                }
                else
                {
                    throw new Exception("Http client initiation has failed.");
                }
                

            }
            catch (Exception ex)
            {

                logger.LogError($"IsConnected -> {ex.Message}");
                logger.LogError($"IsConnected -> Exception: {ex}");

                IMessageBoxView messageBox = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                messageBox.Show();
            }

        }

        public static async Task<TokenVerificationModel> VerifyToken(IFileLogger logger)
        {
            if(string.IsNullOrEmpty(_sessionToken))
            {
                return new TokenVerificationModel()
                {
                    Success = false
                };
            }
            try
            {
                if (ApiClient != null)
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, "verify"))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _sessionToken);

                        using (HttpResponseMessage response = await ApiClient.SendAsync(request))
                        {
                            logger.LogInfo($"VerifyToken -> {response.RequestMessage}");

                            if (response.IsSuccessStatusCode)
                            {
                                TokenVerificationModel tokenVerification = await response.Content.ReadAsAsync<TokenVerificationModel>();

                                if (!tokenVerification.Success)
                                {
                                    _sessionToken = string.Empty;
                                    //tokenVerification.User = null;
                                }
                                else
                                {
                                    if (!tokenVerification.Success)
                                    {
                                        VerificationFailed.Invoke(null, EventArgs.Empty);
                                    }
                                }

                                return tokenVerification;
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Http client initiation has failed.");
                }
            }
            catch (Exception)
            {

                throw;
            }




        }

        //public static string? GetAppSetting(string key)
        //{
        //    return _appSettings.ContainsKey(key) ? _appSettings[key] : null; 
        //}

        //public static void LoadAppSettings(IFileLogger logger)
        //{

        //    foreach (string key in ConfigurationManager.AppSettings)
        //    {
        //        var value = ConfigurationManager.AppSettings[key];
        //        _appSettings[key] = value;
        //        logger.LogInfo($"LoadAppSettings -> {key} : {value}");
        //    }

        //}        


        //public static void UpdateSetting(string key, string value)
        //{
        //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //    if (config.AppSettings.Settings[key] != null)
        //    {
        //        config.AppSettings.Settings[key].Value = value;
        //    }
        //    else
        //    {
        //        config.AppSettings.Settings.Add(key, value);
        //    }

        //    config.Save(ConfigurationSaveMode.Modified);

        //    ConfigurationManager.RefreshSection("appSetting");

        //} 

    }
}
