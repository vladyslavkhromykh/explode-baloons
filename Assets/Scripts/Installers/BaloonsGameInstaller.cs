using Zenject;

public class BaloonsGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Logger>().AsSingle();

        Container.BindFactory<Balloon, BalloonFactory>().FromMonoPoolableMemoryPool(baloon =>
            baloon.WithInitialSize(10).FromComponentInNewPrefabResource("Balloon").UnderTransformGroup("Baloons"));

        Container.BindInterfacesAndSelfTo<BaloonsSpawner>().AsSingle();

        Container.BindInterfacesAndSelfTo<LoseConditionChecker>().AsSingle();
        Container.BindInterfacesAndSelfTo<LoseGameProcessor>().AsSingle();

        Container.Bind<BestRecordHandler>().AsSingle().NonLazy();
        Container.Bind<SessionStarter>().AsSingle();

        Container.DeclareSignal<BalloonExplodedSignal>();
        Container.DeclareSignal<BalloonSpawnedSignal>();
        Container.DeclareSignal<BalloonFlewAwaySignal>();
        Container.DeclareSignal<LoseGameSignal>();
        Container.DeclareSignal<SessionStartSignal>();
        Container.DeclareSignal<SessionEndSignal>();
    }
}