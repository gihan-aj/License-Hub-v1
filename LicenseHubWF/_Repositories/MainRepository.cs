using LicenseHubWF.Models;
using LoggerLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF._Repositories
{
    public class MainRepository : IMainRepository
    {
        private IFileLogger _logger;

        public MainRepository(IFileLogger logger)
        {
            _logger = logger;
        }

        public async Task<LogoutModel> Logout()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, "remote-user/logout"))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(ApiRepository.SessionToken), Encoding.UTF8, "application/json");

                using (var response = await ApiRepository.ApiClient.SendAsync(request))
                {
                    _logger.LogInfo($"Logout -> {response.RequestMessage}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            return JsonConvert.DeserializeObject<LogoutModel>(responseContent);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        }
    }
}
