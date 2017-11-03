using Doods.StdFramework.ApplicationObjects;

namespace CompagnonYgg.iOS
{
    public class Setup : AppSetup
    {

        public Setup()
        {
            ContainerBuilder = Bootstrapper.CreateContainer();
        }
    }
}