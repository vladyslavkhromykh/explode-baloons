using DefaultNamespace;
using Zenject;

public class BaloonsGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<Logger>().AsSingle();
        
        Container.BindFactory<Baloon, BaloonFactory>().FromComponentInNewPrefabResource("BaloonPrefab")
            .WithGameObjectName("Baloon").UnderTransformGroup("Baloons");

        Container.BindInterfacesAndSelfTo<BaloonsSpawner>().AsSingle();

        Container.BindInterfacesAndSelfTo<LoseConditionChecker>().AsSingle();
        Container.BindInterfacesAndSelfTo<LoseGameProcessor>().AsSingle();
        

        Container.DeclareSignal<BaloonExplodedSignal>();
        Container.DeclareSignal<BaloonSpawnedSignal>();
        Container.DeclareSignal<BaloonFlewAwaySignal>();
        Container.DeclareSignal<LoseGameSignal>();
    }
}