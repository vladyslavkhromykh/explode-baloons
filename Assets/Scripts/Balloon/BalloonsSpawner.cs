using ExplodeBalloons.Signals;
using UnityEngine;
using Zenject;

namespace ExplodeBalloons.Balloon
{
    public class BalloonsSpawner : ITickable, IInitializable
    {
        private BalloonFactory Factory;
        private SignalBus SignalBus;
        private float Timer;

        public BalloonsSpawner(BalloonFactory factory, SignalBus signalBus)
        {
            Factory = factory;
            SignalBus = signalBus;
        }

        public void Initialize()
        {
            Spawn();
        }

        public void Tick()
        {
            Timer += Time.deltaTime;

            if (Timer >= 1.0f)
            {
                Timer = 0.0f;
                Spawn();
            }
        }

        public void Spawn()
        {
            BalloonView balloonView = Factory.Create();
            SignalBus.Fire<BalloonSpawnedSignal>(new BalloonSpawnedSignal());
        }
    }
}