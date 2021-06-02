using System;
using UnityEngine;
using Zenject;

public class Logger : IInitializable, IDisposable
{
    private SignalBus SignalBus;

    public Logger(SignalBus signalBus)
    {
        SignalBus = signalBus;
    }

    public void Subscribe()
    {
        SignalBus.Subscribe<BaloonSpawnedSignal>(OnBaloonSpawnedSignal);
        SignalBus.Subscribe<BaloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
        SignalBus.Subscribe<BaloonExplodedSignal>(OnBaloonExplodedSignal);
    }

    public void Unsubscribe()
    {
        SignalBus.Unsubscribe<BaloonSpawnedSignal>(OnBaloonSpawnedSignal);
        SignalBus.Unsubscribe<BaloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
        SignalBus.Unsubscribe<BaloonExplodedSignal>(OnBaloonExplodedSignal);
    }

    public void Initialize()
    {
        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void OnBaloonSpawnedSignal(BaloonSpawnedSignal signal)
    {
        //Debug.Log(nameof(OnBaloonSpawnedSignal));
    }

    private void OnBaloonFlewAwaySignal(BaloonFlewAwaySignal signal)
    {
        //Debug.Log(nameof(OnBaloonFlewAwaySignal));
    }

    private void OnBaloonExplodedSignal(BaloonExplodedSignal signal)
    {
        //Debug.Log(nameof(OnBaloonExplodedSignal));
    }
}