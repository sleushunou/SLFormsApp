using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SLFormsApp.Extensions
{
    public static class NavigationExtensions
    {
        public static Task SetRootAsync(this INavigation navigation, Page page)
        {
            navigation.InsertPageBefore(page, navigation.NavigationStack.First());
            return navigation.PopToRootAsync();
        }
    }
}
