using System;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace SLFormsApp.Pages
{
    public partial class UserListPage : PageBase
    {
        public UserListPage()
        {
            InitializeComponent();
        }

        protected override Type ViewModelType => typeof(UserListViewModel);
    }
}
