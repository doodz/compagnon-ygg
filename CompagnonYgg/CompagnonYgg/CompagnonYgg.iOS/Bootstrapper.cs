using Autofac;
using CompagnonYgg.iOS.Services;
using Doods.StdFramework.Interfaces;

namespace CompagnonYgg.iOS
{
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