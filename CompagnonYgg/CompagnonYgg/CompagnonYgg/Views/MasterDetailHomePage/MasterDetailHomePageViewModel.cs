using CompagnonYgg.Core.Services;
using Doods.StdFramework;
using Doods.StdFramework.Interfaces;
using System;
using System.Linq;

namespace CompagnonYgg.Core.Views.MasterDetailHomePage
{
    public class MasterDetailHomePageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageMenuItem Item { get; set; }
        protected MasterDetailHomePageViewModel(ILogger logger) : base(logger)
        {

            var i = 0;
            MenuItems = new ObservableRangeCollection<MasterDetailPageMenuItem>(new[]
            {
                new MasterDetailPageMenuItem {Id = i++, Title = "Home",TargetType = typeof(WelcomeStartPage.WelcomeStartPage)},
                new MasterDetailPageMenuItem {Id = i++, Title = "Settings",TargetType = typeof(Settings.SettingsPage)},
                new MasterDetailPageMenuItem {Id = i++, Title = "About",TargetType = typeof(About.AboutPage)},

            });

            Item = MenuItems.First();
        }
    }

    public class MasterDetailPageMenuItem
    {
        public MasterDetailPageMenuItem()
        {
            TargetType = typeof(MasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }
        public Action<INavigationService> Navigitation { get; set; }
    }
}
