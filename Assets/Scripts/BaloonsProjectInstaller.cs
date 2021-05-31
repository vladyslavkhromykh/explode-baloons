using UnityEngine;
using Zenject;

public class BaloonsProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.LogError("BaloonsProjectInstaller.InstallBindings");
        
        SignalBusInstaller.Install(Container);

        Container.Bind<IStorage>().To<PlayerPrefsStorage>().AsSingle();
    }
}