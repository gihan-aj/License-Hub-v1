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
    public class LoginRepository : ILoginRepository
    {
        private IFileLogger _logger;

        public event EventHandler LoginSuccessfull;
        public event EventHandler LoginFailed;

        public LoginRepository(IFileLogger logger)
        {
            _logger = logger;
        }

        public async Task<LoginResponseModel> Login(LoginModel loginDetails)
        {
            try
            {
                if (ApiRepository.Connectivity)
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, "remote-user/login"))
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(loginDetails), Encoding.UTF8, "application/json");

                        using (var response = await ApiRepository.ApiClient.SendAsync(request))
                        {
                            _logger.LogInfo($"Login -> {response.RequestMessage}");

                            if (response.IsSuccessStatusCode)
                            {
                                var responseContent = await response.Content.ReadAsStringAsync();
                                try
                                {
                                    return JsonConvert.DeserializeObject<LoginResponseModel>(responseContent);
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
                else
                {
                    throw new Exception("Not connected to server.");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
