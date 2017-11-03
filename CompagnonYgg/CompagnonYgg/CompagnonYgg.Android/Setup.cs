using Autofac;
using CompagnonYgg.Droid.Services;
using Doods.StdFramework.ApplicationObjects;
using Doods.StdFramework.Interfaces;

namespace CompagnonYgg.Droid
{
    public class Setup : AppSetup
    {

        public Setup()
        {
            ContainerBuilder = Bootstrapper.CreateContainer();
        }
    }

    public class Bootstrapper
    {
        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();

            return builder;
        }
    }
}