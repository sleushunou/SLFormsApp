using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SLFormsApp.Interfaces;
using Softeq.XToolkit.Common.Command;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace SLFormsApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        private bool _isLoginValid;
        private bool _isPasswordValid;
        private string _login;
        private string _password;

        public RegisterViewModel(IAuthService loginService, INavigationService navigationService)
        {
            _authService = loginService;
            _navigationService = navigationService;

            RegisterCommand = new AsyncCommand(RegisterAsync);
            LoginCommand = new AsyncCommand(LoginAsync);
        }

        public ICommand LoginCommand { get; }

        public ICommand RegisterCommand { get; }

        public bool IsLoginValid
        {
            get => _isLoginValid;
            set => Set(ref _isLoginValid, value);
        }

        public bool IsPasswordValid
        {
            get => _isPasswordValid;
            set => Set(ref _isPasswordValid, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        private async Task RegisterAsync()
        {
            if (!IsLoginValid || !IsPasswordValid)
            {
                return;
            }

            IsBusy = true;

            var result = await _authService.RegisterAsync(Login, Password);

            if (result.IsSuccess)
            {
                await _navigationService.PushAsync<MainViewModel>(true);
            }
            else
            {
                IsLoginValid = !result.Errors.Any(x => x.Key == "login");
                IsPasswordValid = !result.Errors.Any(x => x.Key == "password");
            }

            IsBusy = false;
        }

        private Task LoginAsync()
        {
            return _navigationService.PushAsync<LoginViewModel>(true);
        }
    }
}
