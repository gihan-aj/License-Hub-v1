using LicenseHubWF.Models;
using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public class LicenseDownloadRepository : ILicenseDownloadRepository
    {
        private IFileLogger _logger;

        public LicenseDownloadRepository(IFileLogger logger)
        {
            _logger = logger;
        }

        public async Task<LicenseStatusModel> CheckLicenseStatus()
        {
            try
            {
                TokenVerificationModel verfication = await ApiRepository.VerifyToken(_logger);
                if (verfication.Success)
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, "remote-user/verify"))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiRepository.SessionToken);

                        using (HttpResponseMessage response = await ApiRepository.ApiClient.SendAsync(request))
                        {
                            _logger.LogInfo($"CheckLicenseStatus -> {response.RequestMessage}");

                            if (response.IsSuccessStatusCode)
                            {
                                LicenseStatusModel licenseStatus = await response.Content.ReadAsAsync<LicenseStatusModel>();

                                return licenseStatus;
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
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveLicense(LicenseModel license)
        {
            throw new NotImplementedException();
        }
    }
}
