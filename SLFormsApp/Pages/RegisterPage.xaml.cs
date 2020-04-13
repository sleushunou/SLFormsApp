using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;

namespace SLFormsApp.Pages
{
    public partial class RegisterPage : PageBase
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(RegisterViewModel);
    }
}
