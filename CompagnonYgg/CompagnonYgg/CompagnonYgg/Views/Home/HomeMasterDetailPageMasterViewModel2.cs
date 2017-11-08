using CompagnonYgg.Core.Views.About;
using CompagnonYgg.Core.Views.Settings;
using Doods.StdFramework;
using Doods.StdFramework.Interfaces;
using System.Linq;

namespace CompagnonYgg.Core.Views.Home
{
    public class HomeMasterDetailPageMasterViewModel2 : BaseViewModel
    {
        public ObservableRangeCollection<HomeMasterDetailPageMenuItem> MenuItems { get; set; }
        public HomeMasterDetailPageMenuItem Item { get; set; }

        public HomeMasterDetailPageMasterViewModel2(ILogger logger) : base(logger)
        {
            var i = 0;
            MenuItems = new ObservableRangeCollection<HomeMasterDetailPageMenuItem>(new[]
            {
                new HomeMasterDetailPageMenuItem
                {
                    Id = i++,
                    Title = "Home",
                    TargetType = typeof(WelcomeStartPage.WelcomeStartPage)
                },
                new HomeMasterDetailPageMenuItem {Id = i++, Title = "Settings", TargetType = typeof(SettingsPage)},
                new HomeMasterDetailPageMenuItem {Id = i, Title = "About", TargetType = typeof(AboutPage)}
            });

            Item = MenuItems.First();
        }
    }
}