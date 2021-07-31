using System;
using ExplodeBalloons.Signals;
using UnityEngine;
using Zenject;

namespace ExplodeBalloons.Common
{
    public class Logger : IInitializable, IDisposable
    {
        private SignalBus SignalBus;

        public Logger(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void Subscribe()
        {
            SignalBus.Subscribe<BalloonSpawnedSignal>(OnBaloonSpawnedSignal);
            SignalBus.Subscribe<BalloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
            SignalBus.Subscribe<BalloonExplodedSignal>(OnBaloonExplodedSignal);
        }

        public void Unsubscribe()
        {
            SignalBus.Unsubscribe<BalloonSpawnedSignal>(OnBaloonSpawnedSignal);
            SignalBus.Unsubscribe<BalloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
            SignalBus.Unsubscribe<BalloonExplodedSignal>(OnBaloonExplodedSignal);
        }

        public void Initialize()
        {
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void OnBaloonSpawnedSignal(BalloonSpawnedSignal signal)
        {
            Debug.Log(nameof(OnBaloonSpawnedSignal));
        }

        private void OnBaloonFlewAwaySignal(BalloonFlewAwaySignal signal)
        {
            Debug.Log(nameof(OnBaloonFlewAwaySignal));
        }

        private void OnBaloonExplodedSignal(BalloonExplodedSignal signal)
        {
            Debug.Log(nameof(OnBaloonExplodedSignal));
        }
    }
}