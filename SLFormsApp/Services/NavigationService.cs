using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using SLFormsApp.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Xamarin.Forms;

namespace SLFormsApp.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation _navigation;

        public INavigation Navigation { set => _navigation = value; }

        public async Task PushAsync<TViewModel>(bool clearBackStack) where TViewModel : ViewModelBase
        {
            var page = CreatePage(typeof(TViewModel));
            if (clearBackStack)
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
            else
            {
                await _navigation.PushAsync(page, true)
                    .ConfigureAwait(false);
            }
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var pageName = viewModelType.FullName.Replace("ViewModel", "Page");
            var viewModelAssemblyName = GetType().GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(
                        CultureInfo.InvariantCulture, "{0}, {1}", pageName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
