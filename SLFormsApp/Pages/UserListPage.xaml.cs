using System;
using System.Threading.Tasks;
using SLFormsApp.Pages.Base;
using SLFormsApp.ViewModels;
using Xamarin.Forms;

namespace SLFormsApp.Pages
{
    public partial class UserListPage : PageBase
    {
        public UserListPage()
        {
            InitializeComponent();
            MyListView.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                if (sender is ListView lv) lv.SelectedItem = null;
            };
        }

        protected override Type ViewModelType => typeof(UserListViewModel);
    }
}
