using UnityEngine;
using Zenject;

public class BaloonsGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Logger>().AsSingle();
        
        Debug.LogError("BaloonsGameInstaller.InstallBindings");
        
        Container.BindFactory<Baloon, BaloonFactory>().FromComponentInNewPrefabResource("BaloonPrefab")
            .WithGameObjectName("Baloon").UnderTransformGroup("Baloons");

        Container.BindInterfacesAndSelfTo<BaloonsSpawner>().AsSingle();

        Container.BindInterfacesAndSelfTo<LoseConditionChecker>().AsSingle();
        Container.BindInterfacesAndSelfTo<LoseGameProcessor>().AsSingle();
        
        Container.Bind<SessionStarter>().AsSingle();
        Container.Bind<SessionTimeCounter>().AsSingle();
        
        Container.DeclareSignal<BaloonExplodedSignal>();
        Container.DeclareSignal<BaloonSpawnedSignal>();
        Container.DeclareSignal<BaloonFlewAwaySignal>();
        Container.DeclareSignal<LoseGameSignal>();
        Container.DeclareSignal<SessionStartSignal>();
        Container.DeclareSignal<SessionEndSignal>();
    }
}