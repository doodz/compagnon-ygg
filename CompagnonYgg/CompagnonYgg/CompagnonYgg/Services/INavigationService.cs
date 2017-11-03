using System.Threading.Tasks;
using Xamarin.Forms;

namespace CompagnonYgg.Core.Services
{
    public interface INavigationService
    {
        INavigation Navigation { get; set; }
        Task GoToHome();
        Task GoToSettings();
        Task GoToAbout();

        Page GetWelcomeStartPage();
        Page GetRootPage();
    }
}
