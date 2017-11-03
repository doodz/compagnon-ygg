using Doods.StdFramework.ApplicationObjects;

namespace CompagnonYgg.UWP
{
    public class Setup : AppSetup
    {

        public Setup()
        {
            ContainerBuilder = Bootstrapper.CreateContainer();
        }
    }
}