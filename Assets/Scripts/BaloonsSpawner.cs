using UnityEngine;
using Zenject;

public class BaloonsSpawner : ITickable, IInitializable
{
    private BaloonFactory Factory;
    private SignalBus SignalBus;
    private float Timer;

    public BaloonsSpawner(BaloonFactory factory, SignalBus signalBus)
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
        Baloon baloon = Factory.Create();
        SignalBus.Fire<BaloonSpawnedSignal>(new BaloonSpawnedSignal(baloon));
    }
}