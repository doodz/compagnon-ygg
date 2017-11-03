using Autofac;
using CompagnonYgg.UWP.Services;
using Doods.StdFramework.Interfaces;

namespace CompagnonYgg.UWP
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