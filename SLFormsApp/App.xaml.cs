using Autofac;
using Plugin.Settings;
using SLFormsApp.Interfaces;
using SLFormsApp.Pages;
using SLFormsApp.Services;
using SLFormsApp.ViewModels;
using Softeq.XToolkit.WhiteLabel.Bootstrapper;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Xamarin.Forms;

namespace SLFormsApp
{
    public partial class App : Application
    {
        public ILifetimeScope Scope { get; }

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<Database>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().InstancePerDependency();
            builder.RegisterType<LoginViewModel>().InstancePerDependency();
            builder.RegisterType<RegisterViewModel>().InstancePerDependency();
            builder.RegisterType<ProfileViewModel>().InstancePerDependency();
            builder.RegisterType<MainViewModel>().InstancePerDependency();
            builder.RegisterType<ProfilesListViewModel>().InstancePerDependency();
            Scope = builder.Build().BeginLifetimeScope();

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
