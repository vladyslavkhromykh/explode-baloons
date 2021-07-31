using ExplodeBalloons.Balloon;
using Zenject;

namespace ExplodeBalloons.Installers
{
    public class BalloonInstaller : MonoInstaller
    {
        public BalloonView BalloonView;

        public override void InstallBindings()
        {
            Container.Bind<BalloonModel>().AsSingle();
            Container.BindInterfacesTo<BalloonFlyBehaviour>().AsSingle().WithArguments(BalloonView).NonLazy();
            Container.BindInterfacesTo<BalloonCameraLimitsChecker>().AsSingle().WithArguments(BalloonView).NonLazy();
            //Container.BindInterfacesTo<BalloonAccelerator>().AsSingle().NonLazy();
        }
    }
}