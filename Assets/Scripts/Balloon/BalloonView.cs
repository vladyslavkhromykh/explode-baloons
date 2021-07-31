using System;
using ExplodeBalloons.Common;
using ExplodeBalloons.Signals;
using UnityEngine;
using Zenject;

namespace ExplodeBalloons.Balloon
{
    public class BalloonView : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        private BalloonModel BalloonModel;
        private IMemoryPool Pool;
        private SignalBus SignalBus;
        private Settings Settings;

        [Inject]
        public void Construct(BalloonModel model, SignalBus signalBus, Settings settings)
        {
            BalloonModel = model;
            SignalBus = signalBus;
            Settings = settings;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            Pool = pool;
            MoveToFlyStartPosition();
            BalloonModel.IsAlive = true;
        }

        public void OnDespawned()
        {
            Pool = null;
            ResetView();
        }

        public void Dispose()
        {
            Pool?.Despawn(this);
        }

        private void ResetView()
        {
            MoveToFlyStartPosition();
            BalloonModel.IsAlive = false;
            BalloonModel.Speed = Settings.BaloonStartSpeed;
        }

        private void Awake()
        {
            ResetView();
        }

        public void LateUpdate()
        {
            if (!BalloonModel.IsAlive)
            {
                return;
            }

            transform.position = BalloonModel.Position;
        }

        public Vector3 GetSize()
        {
            return GetComponent<BoxCollider>().size;
        }

        public void OnMouseDown()
        {
            SignalBus.Fire<BalloonExplodedSignal>(new BalloonExplodedSignal(BalloonModel));
            Dispose();
        }

        private void MoveToFlyStartPosition()
        {
            BalloonModel.Position = new BaloonSpawnPositionGenerator().Generate(this);
        }
    }
}