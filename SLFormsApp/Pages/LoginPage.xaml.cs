using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;

namespace SLFormsApp.Pages
{
    public partial class LoginPage : PageBase
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(LoginViewModel);
    }
}
