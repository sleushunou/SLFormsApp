using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;
using Xamarin.Forms;

namespace SLFormsApp.Pages
{
    public partial class ProfilePage : PageBase
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(ProfileViewModel);
    }
}
