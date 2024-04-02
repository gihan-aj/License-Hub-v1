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
using System.Windows.Forms;

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
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BaseRepository.SessionToken);

                using(HttpResponseMessage response = await BaseRepository.HttpClientService.SendAsync(request)) 
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
            using(var request = new HttpRequestMessage(HttpMethod.Get, "packages"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BaseRepository.SessionToken);

                using(HttpResponseMessage response = await BaseRepository.HttpClientService.SendAsync(request))
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

        }

        // License agreement
        public void VisitLicenseAgreement()
        {
            string filePath = BaseRepository.GetSetting<string>("LicenseAgreementPath");

            if(File.Exists(filePath))
            {
                
                System.Diagnostics.Process.Start(BaseRepository.GetSetting<string>("TxtReader"),filePath);
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

    }
}
