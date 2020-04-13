using System.Threading.Tasks;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Xamarin.Forms;

namespace SLFormsApp.Interfaces
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(bool clearBackStack = false) where TViewModel : ViewModelBase;

        INavigation Navigation { set; }
    }
}
