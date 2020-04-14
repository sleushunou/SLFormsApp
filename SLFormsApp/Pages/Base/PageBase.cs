using System;
using Autofac;
using SLFormsApp.Interfaces;
using Xamarin.Forms;

namespace SLFormsApp.Pages.Base
{
    public abstract class PageBase : ContentPage
    {
        public PageBase()
        {
            var container = ((App)Application.Current).Scope;

            var navigationService = container.Resolve<INavigationService>();
            navigationService.Navigation = Navigation;

            BindingContext = container.Resolve(ViewModelType, new TypedParameter(typeof(INavigationService), navigationService));
        }

        protected abstract Type ViewModelType { get; }
    }
}
