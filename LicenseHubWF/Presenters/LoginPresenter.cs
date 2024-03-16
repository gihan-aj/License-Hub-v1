using LicenseHubWF._Repositories;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Presenters
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private ILoginRepository _repository;
        private IFileLogger _logger;

        private event EventHandler _loginSuccessfullEvent;
        private event EventHandler _loginFailedEvent;
        public LoginPresenter(ILoginView view, ILoginRepository repository, IFileLogger logger)
        {
            _view = view;
            _repository = repository;
            _logger = logger;

            // Events
            _view.LoginEvent += LoginAndGetSessionToken;

            // Showing login view
            view.Show();
        }

        private async void LoginAndGetSessionToken(object? sender, EventArgs e)
        {
            try
            {
                LoginModel loginUser = new LoginModel()
                {
                    Email = _view.Email,
                    Password = _view.Password,
                };

                LoginResponseModel loginDetails = await _repository.Login(loginUser);

                _logger.LogInfo($"LoginAndGetSessionToken -> {loginDetails.Message}");

                if( loginDetails != null )
                {
                    if(loginDetails.Success )
                    {
                        ApiRepository.SessionToken = loginDetails.SessionToken;
                        ApiRepository.User = loginDetails.User;

                        _loginSuccessfullEvent.Invoke(this, EventArgs.Empty); 

                        _logger.LogInfo($"LoginAndGetSessionToken -> {loginDetails.User.Name} logged in with {loginDetails.User.Email}.");
                        _logger.LogInfo($"LoginAndGetSessionToken -> Session Token {loginDetails.SessionToken}.");

                        _view.Dispose();
                    }
                    else
                    {
                        _loginFailedEvent.Invoke(this, EventArgs.Empty);
                        IMessageBoxView confirmView = new MessageBoxView()
                        {
                            Title = "Warning",
                            Message = loginDetails.Message,
                        };
                        confirmView.Show();
                        _logger.LogError($"LoginAndGetSessionToken -> {loginDetails.Message}");
                    }
                }
                else
                {
                    _loginFailedEvent.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                await ApiRepository.IsConnected(_logger);
                IMessageBoxView confirmView = new MessageBoxView()
                {
                    Title = "Error",
                    Message = ex.Message
                };
                confirmView.Show();
                _logger.LogError($"LoginAndGetSessionToken -> {ex.Message}");
            }


        }
    }
}
