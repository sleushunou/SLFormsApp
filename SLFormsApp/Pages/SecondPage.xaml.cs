using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace SLFormsApp.Pages
{
    public partial class SecondPage : PageBase
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(ProfilesListViewModel);
    }
}
