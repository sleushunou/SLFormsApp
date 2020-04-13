using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;
using Xamarin.Forms;

namespace SLFormsApp.Pages
{
    public partial class FirstPage : PageBase
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(ProfileViewModel);
    }
}
