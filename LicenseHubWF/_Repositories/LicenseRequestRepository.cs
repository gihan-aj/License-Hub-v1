using LicenseHubWF.Models;
using LoggerLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace LicenseHubWF._Repositories
{
    public class LicenseRequestRepository : ILicenseRequestRepository
    {
        // Fields
        private IFileLogger _logger;

        // Constructor
        public LicenseRequestRepository(IFileLogger logger) 
        {
            _logger = logger;
        }

        // Methods
        // Client list
        public async Task<IEnumerable<ClientModel>> GetClients()
        {
            using(var request = new HttpRequestMessage(HttpMethod.Get, "clients"))
            {
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", sessionToken);

                using(HttpResponseMessage response = await ApiRepository.ApiClient.SendAsync(request)) 
                {
                    _logger.LogInfo($"GetClients -> {response.RequestMessage}");

                    if (response.IsSuccessStatusCode)
                    {
                        List<ClientModel> clientList = await response.Content.ReadAsAsync<List<ClientModel>>();

                        return clientList;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }

        }

        // Package list
        public async Task<IEnumerable<PackageModel>> GetPackages()
        {

            using (HttpResponseMessage response = await ApiRepository.ApiClient.GetAsync("packages"))
            {
                _logger.LogInfo($"GetPackages -> {response.RequestMessage}");

                if (response.IsSuccessStatusCode)
                {
                    List<PackageModel> packageList = await response.Content.ReadAsAsync<List<PackageModel>>();

                    return packageList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        // Request key
        public string GetRequestKey()
        {
            try
            {
                string hardwareId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", null).ToString();
                hardwareId.Replace("{", "").Replace("}", "").Trim();

                //Encryption
                // The key and initialization factor
                byte[] key = new byte[16];
                byte[] iv = new byte[16];

                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                    rng.GetBytes(iv);
                }

                byte[] encryptedHardwareId = Encrypt(hardwareId, key, iv);
                string requestKey = Convert.ToBase64String(encryptedHardwareId);

                return hardwareId.Replace("{", "").Replace("}", "").Trim().ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        // PC name
        public string GetPCName()
        {

            return Environment.MachineName;
     
        }

        // License agreement
        public void VisitLicenseAgreement()
        {
            string filePath = ApiRepository.GetSetting<string>("LicenseAgreementPath");

            if(File.Exists(filePath))
            {
                
                System.Diagnostics.Process.Start(ApiRepository.GetSetting<string>("TxtReader"),filePath);
            }
            else
            {
                throw new FileNotFoundException("License Agreement not found.");
            }
            
        }

        // Request license
        public void Request(LicenseRequestModel licenseRequest)
        {
            
        }

        private byte[] Encrypt(string simpleText, byte[] key, byte[] iv)
        {
            byte[] cipheredText;

            using(Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using(MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(simpleText);
                        }

                        cipheredText = memoryStream.ToArray();
                    }   
                }
            }

            return cipheredText;
        }

        private string Decrypt(byte[] cipheredText, byte[] key, byte[] iv)
        {
            string simpleText = String.Empty;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream(cipheredText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            simpleText = reader.ReadToEnd();
                        }
                    }
                }
            }
            return simpleText;
        }


    }
}
