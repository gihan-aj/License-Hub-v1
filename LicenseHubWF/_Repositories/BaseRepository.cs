using LicenseHubWF.Models;
using LoggerLib;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseHubWF.Views;
using System.Reflection;
using System.Net.Http.Headers;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using static LicenseHubWF.Models.AppServiceModel;

namespace LicenseHubWF._Repositories
{
    public static class BaseRepository
    {
        // Fields
        private static HttpClient? _httpClient;
        private static UserModel? _user;
        private static string? _sessionToken;
        private static bool _connectivity = false;
        private static AppSettingsModel _appSettings = new AppSettingsModel();
        private static string _appSettingFilePath = string.Empty;
        private static string _requestKey = string.Empty;
        private static bool _authorizedUser = false;

        // Events
        public static event EventHandler? ConnectivityChanged;
        public static event EventHandler? UserChanged;
        public static event EventHandler? LoggedOut;
        public static event EventHandler? AuthorizationFailed;

        // Properties 
        public static HttpClient? HttpClientService
        {
            get
            {
                if (_httpClient != null)
                {
                    return _httpClient;
                }
                else
                {
                    throw new Exception("Http client does not initialized.");
                }
            }
            private set
            {
                _httpClient = value;
            }
        }
        public static UserModel? User
        {
            get => _user;
            set
            {
                _user = value;
                if (_user != null)
                {
                    UserChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static string? SessionToken { get => _sessionToken; set => _sessionToken = value; }
        public static bool Connectivity
        {
            get => _connectivity;
            set
            {
                _connectivity = value;
                ConnectivityChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        public static AppSettingsModel AppSettings { get => _appSettings; set => _appSettings = value; }
        public static string RequestKey { get => _requestKey; private set => _requestKey = value; }
        public static bool AuthorizedUser 
        {
            set 
            {
                _authorizedUser = value;
                if(!_authorizedUser)
                {
                    AuthorizationFailed?.Invoke(null, EventArgs.Empty);
                }
            } 
        }

        // Methods
        // App setiings
        public static void LoadAppSettings(IFileLogger logger)
        {
            try
            {
                _appSettingFilePath = Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.json");
                if (!File.Exists(_appSettingFilePath))
                {
                    var initialSettings = AppSettings;
                    SaveAppSettings(AppSettings, _appSettingFilePath);

                    logger.LogInfo($"LoadAppSettings -> App settings created.");
                }
                else
                {
                    string jsonContent = File.ReadAllText(_appSettingFilePath);
                    _appSettings = JsonConvert.DeserializeObject<AppSettingsModel>(jsonContent) ??
                        throw new JsonException("Remove AppSettings file from directory and restart");

                    logger.LogInfo($"LoadAppSettings -> App settings loaded.");

                }
            }
            catch (Exception ex)
            {
                logger.LogError($"LoadAppSettings -> {ex.Message}");
                logger.LogError($"LoadAppSettings -> Exception: {ex}");
                ShowMessage("Error", ex.Message);
            }
        }

        private static void SaveAppSettings(AppSettingsModel settings, string filePath)
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

            File.WriteAllText(filePath, jsonString);
        }

        public static void UpdateAppSettings(string property, string value, IFileLogger logger)
        {
            try
            {
                PropertyInfo propertyInfo = _appSettings.GetType().GetProperty(property) ??
                    throw new Exception("Setting not found.");

                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(_appSettings, value);
                }
                else
                {
                    logger.LogError($"UpdateAppSettings -> Property ({property}) is read-only");
                    throw new Exception($"Setting ({property}) is read-only");
                }

                SaveAppSettings(_appSettings, _appSettingFilePath);
            }
            catch (Exception ex)
            {
                logger.LogError($"UpdateAppSettings -> Property ({property}) : {ex.Message}");
                logger.LogError($"UpdateAppSettings -> Exception: {ex}");
                ShowMessage("Error", ex.Message);
            }
        }

        public static T GetSetting<T>(string property)
        {
            try
            {
                PropertyInfo propertyInfo = _appSettings.GetType().GetProperty(property)
                    ?? throw new Exception($"Setting({property}) not found.");

                if (propertyInfo != null && propertyInfo.CanRead)
                {
                    return (T)propertyInfo.GetValue(_appSettings)!;
                }
                else
                {
                    throw new Exception($"Setting({property}) cannot be read.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ShowMessage(string title, string message)
        {
            IMessageBoxView messageBox = new MessageBoxView()
            {
                Title = title,
                Message = message
            };
            messageBox.Show();
        }

        // Http client
        private static void InitializeHTTPClient(string baseUrl)
        {
            try
            {
                if (baseUrl != null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(baseUrl);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        public static async Task EstablishConnection(IFileLogger logger)
        {
            try
            {
                Connectivity = false;
                string baseUrl = GetSetting<string>("ApiBaseUrl");
                if (baseUrl != null)
                {
                    InitializeHTTPClient(baseUrl);

                    if (HttpClientService != null)
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Get, "test"))
                        {
                            using (var response = await HttpClientService.SendAsync(request))
                            {
                                logger.LogInfo($"EstablishConnection -> {response.RequestMessage}");

                                if (response.IsSuccessStatusCode)
                                {
                                    TestModel testResponse = await response.Content.ReadAsAsync<TestModel>();
                                    if (!string.IsNullOrEmpty(testResponse.Message))
                                    {
                                        Connectivity = true;
                                        logger.LogInfo($"EstablishConnection -> Server connection working.");
                                    }
                                    else
                                    {
                                        Connectivity = false;
                                        logger.LogError($"EstablishConnection -> Incorrect url");
                                    }
                                }
                                else
                                {
                                    Connectivity = false;
                                    logger.LogError($"EstablishConnection -> {response.ReasonPhrase}");
                                    ShowMessage("Error", response.ReasonPhrase!);
                                }
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
            catch (Exception ex)
            {
                logger.LogError($"EstablishConnection -> {ex.Message} ");
                logger.LogError($"EstablishConnection -> Exception: {ex}");
                ShowMessage("Error", ex.Message);
            }
        }

        public static void GetRequestKey(IFileLogger logger)
        {
            try
            {
                string hardwareProfileGuid = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", null)
                    as string ?? throw new Exception("Could not find the Hardware Profile of the server");
                hardwareProfileGuid.Replace("{", "").Replace("}", "").Trim();

                //byte[] sharedSecretKey = new byte[32]; // Allocate 32 bytes for AES-256 key
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(sharedSecretKey);
                //}

                //logger.LogInfo($"GetRequestKey -> Key : {Convert.ToBase64String(sharedSecretKey)} ");

                //byte[] sharedSecretKey = Encoding.ASCII.GetBytes("l+H4GSj1TJJ52iogo6xd2dsb5M/483aCyVhXiAsz1QY=");

                byte[] sharedSecretKey = CreateKey("shared_secret_keyyyyy");

                byte[] hashedHardwareProfileGuid = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(hardwareProfileGuid));

                // AES encryptor
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.Key = sharedSecretKey;
                    aes.GenerateIV();

                    byte[] encryptedData = EncryptStringToByteArray(hashedHardwareProfileGuid, aes);

                    string encryptedHardwareProfileGuid = Convert.ToBase64String(encryptedData);

                    logger.LogInfo($"GetRequestKey -> Request key: {encryptedHardwareProfileGuid} ");

                    RequestKey = encryptedHardwareProfileGuid;
                }
            }
            catch (Exception ex)
            {
                
                logger.LogError($"GetRequestKey -> {ex.Message} ");
                logger.LogError($"GetRequestKey -> Exception: {ex}");
                ShowMessage("Error", ex.Message);
            }
        }

        private static byte[] EncryptStringToByteArray(byte[] data, Aes aes)
        {
            using(var encryptor = aes.CreateEncryptor())
            using(var ms = new MemoryStream())
            {
                using(var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }

        private static byte[] CreateKey(string sharedKey)
        {
            byte[] byteArray = new byte[32];
            Encoding.UTF8.GetBytes(sharedKey, 0, sharedKey.Length, byteArray, 0);

            if(sharedKey.Length < 32 )
            {
                Array.Copy(byteArray, 0, byteArray, 0, sharedKey.Length);
            }
            else
            {
                Array.Copy(byteArray, 0, byteArray, 0, 32);
            }
            return byteArray;
        }

        public static async Task<bool> VerifyToken(IFileLogger logger)
        {
            if (string.IsNullOrEmpty(_sessionToken))
            {
                return false;
            }
            try
            {
                using(var request = new HttpRequestMessage(HttpMethod.Get, $"verify-token/{_sessionToken}"))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _sessionToken);

                    using(HttpResponseMessage response = await HttpClientService.SendAsync(request))
                    {
                        logger.LogInfo($"VerifyToken -> {response.RequestMessage}");

                        if(response.IsSuccessStatusCode)
                        {
                            VerificationResponse verification = await response.Content.ReadAsAsync<VerificationResponse>();
                            if(verification != null )
                            {
                                logger.LogInfo($"VerifyToken -> {verification.message}");
                                if (verification.flag)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

    }
}
