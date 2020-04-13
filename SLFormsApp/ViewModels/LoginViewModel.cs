using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SLFormsApp.Interfaces;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace SLFormsApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthService _loginService;
        private readonly INavigationService _navigationService;

        private bool _isLoginValid;
        private bool _isPasswordValid;
        private string _login;
        private string _password;

        public LoginViewModel(IAuthService loginSerice, INavigationService navigationService)
        {
            _loginService = loginSerice;
            _navigationService = navigationService;

            IsLoginValid = true;
            IsPasswordValid = true;

            LoginCommand = new AsyncCommand(LoginAsync);
            RegisterCommand = new AsyncCommand(RegisterAsync);
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

        private async Task LoginAsync()
        {
            IsLoginValid = true;
            IsPasswordValid = true;

            IsBusy = true;

            var result = await _loginService.LoginAsync(Login, Password);

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

        private Task RegisterAsync()
        {
            return _navigationService.PushAsync<RegisterViewModel>(true);
        }
    }
}
