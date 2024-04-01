using LicenseHubWF._Repositories;
using LicenseHubWF.Models;
using LicenseHubWF.Views;
using LoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicenseHubWF.Models.AppServiceModel;

namespace LicenseHubWF.Presenters
{
    public class LoginPresenter
    {
        private LoginView _view;
        private ILoginRepository _repository;
        private IFileLogger _logger;

        public LoginPresenter(ILoginRepository repository, IFileLogger logger)
        {
            _view = LoginView.GetInstance();
            _repository = repository;
            _logger = logger;

            // Events
            _view.LoginEvent += LoginAndGetSessionToken;

            // Showing login view
            _view.Show();
        }

        private async void LoginAndGetSessionToken(object? sender, EventArgs e)
        {
            try
            {
                var loginRequest = new LoginRequest(_view.Email, _view.Password);
                var loginResponse = await _repository.Login(loginRequest);

                if (loginResponse != null)
                {
                    _logger.LogInfo($"LoginAndGetSessionToken -> {loginResponse.message}");

                    if(loginResponse.flag)
                    {
                        BaseRepository.SessionToken = loginResponse.token;
                        BaseRepository.User = loginResponse.user;

                        _logger.LogInfo($"LoginAndGetSessionToken -> {loginResponse.user.Name} logged in with {loginResponse.user.Email}.");
                        _logger.LogInfo($"LoginAndGetSessionToken -> Session Token {loginResponse.token}.");

                        _view.Dispose();
                    }
                    else
                    {
                        BaseRepository.ShowMessage("Info", loginResponse.message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"LoginAndGetSessionToken -> {ex.Message}");
                _logger.LogError($"LoginAndGetSessionToken -> Exception: {ex}");

                BaseRepository.ShowMessage("Error", ex.Message);

            }
        }

        //private async void LoginAndGetSessionToken(object? sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoginModel loginUser = new LoginModel()
        //        {
        //            Email = _view.Email,
        //            Password = _view.Password,
        //        };

        //        LoginResponseModel loginDetails = await _repository.Login(loginUser);

        //        _logger.LogInfo($"LoginAndGetSessionToken -> {loginDetails.Message}");

        //        if( loginDetails != null )
        //        {
        //            if(loginDetails.Success )
        //            {
        //                ApiRepository.SessionToken = loginDetails.SessionToken;
        //                ApiRepository.User = loginDetails.User;


        //                _logger.LogInfo($"LoginAndGetSessionToken -> {loginDetails.User.Name} logged in with {loginDetails.User.Email}.");
        //                _logger.LogInfo($"LoginAndGetSessionToken -> Session Token {loginDetails.SessionToken}.");

        //                _view.Dispose();
        //            }
        //            else
        //            {
        //                IMessageBoxView confirmView = new MessageBoxView()
        //                {
        //                    Title = "Warning",
        //                    Message = loginDetails.Message,
        //                };
        //                confirmView.Show();
        //                _logger.LogError($"LoginAndGetSessionToken -> {loginDetails.Message}");
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await ApiRepository.IsConnected(_logger);
        //        IMessageBoxView confirmView = new MessageBoxView()
        //        {
        //            Title = "Error",
        //            Message = ex.Message
        //        };
        //        confirmView.Show();
        //        _logger.LogError($"LoginAndGetSessionToken -> {ex.Message}");
        //    }


    }
    
}
