using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SLFormsApp.Interfaces;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Threading;

namespace SLFormsApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        public ProfileViewModel(IAuthService authService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _authService = authService;

            LogoutCommand = new AsyncCommand(LogoutAsync);
        }

        public ICommand LogoutCommand { get; }

        private async Task LogoutAsync()
        {
            IsBusy = true;

            await _authService.LogoutAsync();

            await _navigationService.PushAsync<LoginViewModel>(true);

            IsBusy = false;
        }
    }
}
