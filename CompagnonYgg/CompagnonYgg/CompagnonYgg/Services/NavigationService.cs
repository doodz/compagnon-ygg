using CompagnonYgg.Core.Views.About;
using CompagnonYgg.Core.Views.Settings;
using CompagnonYgg.Core.Views.WelcomeStartPage;
using Doods.StdFramework.Navigation;
using System.Threading.Tasks;
using CompagnonYgg.Core.Views.NewFolder1;
using Xamarin.Forms;

namespace CompagnonYgg.Core.Services
{
    public class NavigationService : BaseNavigationService, INavigationService
    {
        public Task GoToHome()
        {
            return PushAsync(Navigation, new MasterDetailPage());
        }

        public Task GoToSettings()
        {
            return PushAsync(Navigation, new SettingsPage());
        }

        public Task GoToAbout()
        {
            return PushAsync(Navigation, new AboutPage());
        }

        public Page GetWelcomeStartPage()
        {
            return new DoodsNavigationPage(new WelcomeStartPage());
        }

        public Page GetRootPage()
        {
            return new DoodsNavigationPage(new HomeMasterDetailPage());
        }
    }
}