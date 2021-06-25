using UnityEngine;
using Zenject;

public class BaloonsSpawner : ITickable, IInitializable
{
    private BalloonFactory Factory;
    private SignalBus SignalBus;
    private float Timer;

    public BaloonsSpawner(BalloonFactory factory, SignalBus signalBus)
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

        if (Timer >= 0.2f)
        {
            Timer = 0.0f;
            Spawn();
        }
    }

    public void Spawn()
    {
        Balloon balloon = Factory.Create();
        SignalBus.Fire<BalloonSpawnedSignal>(new BalloonSpawnedSignal(balloon));
    }
}