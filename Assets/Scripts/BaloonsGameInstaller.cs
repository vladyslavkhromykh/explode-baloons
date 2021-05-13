using DefaultNamespace;
using Zenject;

public class BaloonsGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindFactory<Baloon, BaloonFactory>().FromComponentInNewPrefabResource("BaloonPrefab")
            .WithGameObjectName("Baloon").UnderTransformGroup("Baloons");

        Container.BindInterfacesAndSelfTo<BaloonsSpawner>().AsSingle();

        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<BaloonExplodedSignal>();
        Container.DeclareSignal<BaloonSpawnedSignal>();
        Container.DeclareSignal<BaloonFlewAwaySignal>();
    }
}