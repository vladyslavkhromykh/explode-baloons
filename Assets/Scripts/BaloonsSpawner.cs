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

        if (Timer >= 1.0f)
        {
            Timer = 0.0f;
            Spawn();
        }
    }

    public void Spawn()
    {
        Baloon baloon = Factory.Create();
        baloon.transform.position = GetSpawnPosition(baloon);
        SignalBus.Fire<BaloonSpawnedSignal>(new BaloonSpawnedSignal(baloon));
    }

    public Vector3 GetSpawnPosition(Baloon baloon)
    {
        Vector3 spawnPosition =
            Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 0.0f), 0.0f));
        spawnPosition.y -= baloon.GetSize().y;
        spawnPosition.z = 0.0f;
        return spawnPosition;
    }
}