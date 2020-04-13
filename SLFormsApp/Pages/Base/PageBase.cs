using System;
using SLFormsApp.Interfaces;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Xamarin.Forms;

namespace SLFormsApp.Pages.Base
{
    public abstract class PageBase : ContentPage
    {
        public PageBase()
        {
            var container = ((App)Application.Current).Container;

            var navigationService = container.Resolve<INavigationService>();
            navigationService.Navigation = Navigation;

            BindingContext = 
                typeof(IContainer).GetMethod("Resolve").MakeGenericMethod(ViewModelType)
                .Invoke(container, new object[] { new object[1] { navigationService } });
        }

        protected abstract Type ViewModelType { get; }
    }
}
