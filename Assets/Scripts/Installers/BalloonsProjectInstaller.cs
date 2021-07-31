using UnityEngine;
using Zenject;

public class BalloonsProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        
        Container.Bind<IStorage>().To<DiskStorage>().AsSingle();
    }
}