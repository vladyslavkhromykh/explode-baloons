using ExplodeBalloons.Storage;
using Zenject;

namespace ExplodeBalloons.Installers
{
    public class BalloonsProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind<IStorage>().To<DiskStorage>().AsSingle();
        }
    }
}