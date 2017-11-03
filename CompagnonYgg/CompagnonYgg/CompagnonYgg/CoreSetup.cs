using Autofac;
using CompagnonYgg.Core.Services;
using CompagnonYgg.Core.Views.Settings;
using CompagnonYgg.Core.Views.WelcomeStartPage;

using Doods.StdFramework.ApplicationObjects;
namespace CompagnonYgg.Core
{
    public static class CoreSetup
    {
        public static void SetupContainer(AppSetup appSetup)
        {


            //appSetup.ContainerBuilder.RegisterType<MasterDetailHomePageViewModel>().AsSelf();
            appSetup.ContainerBuilder.RegisterType<AboutPageViewModel>().AsSelf();
            appSetup.ContainerBuilder.RegisterType<SettingsPageViewModel>().AsSelf();
            appSetup.ContainerBuilder.RegisterType<WelcomeStartPageViewModel>().AsSelf();

            //appSetup.ContainerBuilder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            //appSetup.ContainerBuilder.RegisterType<RepositoryBase>().As<IRepository>();

            //appSetup.ContainerBuilder.RegisterType<SQLiteFactory>().As<ISQLiteFactory>().SingleInstance();
            appSetup.ContainerBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            var container = appSetup.Build();
        }
    }
}