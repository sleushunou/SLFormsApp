using Plugin.Settings;
using SLFormsApp.Interfaces;
using SLFormsApp.Pages;
using SLFormsApp.Services;
using SLFormsApp.ViewModels;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Containers;
using Xamarin.Forms;

namespace SLFormsApp
{
    public partial class App : Application
    {
        public IContainer Container { get; }

        public App()
        {
            InitializeComponent();

            var builder = new DryIocContainerBuilder();
            builder.Singleton<AuthService, IAuthService>();
            builder.Singleton<Database>();
            builder.PerDependency<NavigationService, INavigationService>();
            builder.PerDependency<LoginViewModel>();
            builder.PerDependency<RegisterViewModel>();
            builder.PerDependency<ProfileViewModel>();
            builder.PerDependency<MainViewModel>();
            builder.PerDependency<ProfilesListViewModel>();
            Container = builder.Build();

            if (CrossSettings.Current.GetValueOrDefault(Defines.CurrentUserKey, null) == null)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
