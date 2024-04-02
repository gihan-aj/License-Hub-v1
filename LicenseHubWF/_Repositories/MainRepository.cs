using LicenseHubWF.Models;
using LoggerLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicenseHubWF.Models.AppServiceModel;

namespace LicenseHubWF._Repositories
{
    public class MainRepository : IMainRepository
    {
        private IFileLogger _logger;

        public MainRepository(IFileLogger logger)
        {
            _logger = logger;
        }

        public async Task<LogoutResponse> Logout()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "Logout"))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(BaseRepository.SessionToken), Encoding.UTF8, "application/json");

                using (var response = await BaseRepository.HttpClientService.SendAsync(request))
                {
                    _logger.LogInfo($"Logout -> {response.RequestMessage}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        
                        return JsonConvert.DeserializeObject<LogoutResponse>(responseContent)?? throw new JsonException();
                        
                    }
                    else
                    {
                        throw new Exception("logout failed");
                    }
                }
            }
        }
    }
}
