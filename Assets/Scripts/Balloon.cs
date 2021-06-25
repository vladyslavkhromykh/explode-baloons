using System;
using UnityEngine;
using Zenject;

public class Balloon : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
{
    private IMemoryPool Pool;
    private SignalBus SignalBus;
    private Settings Settings;
    private float StartSpeed;
    public bool Alive;

    [Inject]
    public void Construct(SignalBus signalBus, Settings settings)
    {
        SignalBus = signalBus;
        Settings = settings;
    }

    public void OnSpawned(IMemoryPool pool)
    {
        Pool = pool;
        MoveToFlyStartPosition();
        Alive = true;
    }

    public void OnDespawned()
    {
        Pool = null;
        Reset();
    }

    public void Dispose()
    {
        Pool?.Despawn(this);
    }
    
    private void Reset()
    {
        MoveToFlyStartPosition();
        Alive = false;
        StartSpeed = Settings.BaloonStartSpeed;
    }
    
    private void Awake()
    {
        Reset();
    }

    public void Update()
    {
        if (!Alive)
        {
            return;
        }

        Accelerate();
        Fly();
        CheckCameraLimits();
    }

    private void Fly()
    {
        Vector3 position = transform.position;
        position.y += GetSpeed() * Time.deltaTime;
        transform.position = position;
    }

    private void Accelerate()
    {
        StartSpeed += Time.deltaTime;
    }

    public float GetSpeed()
    {
        return StartSpeed;
    }

    private void CheckCameraLimits()
    {
        Vector3 topLimit = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, 0.0f));

        Vector3 position = transform.position;
        position.y -= GetSize().y * 0.5f;

        if (position.y > topLimit.y)
        {
            FlyAway();
        }
    }

    public Vector3 GetSize()
    {
        return GetComponent<BoxCollider>().size;
    }

    private void FlyAway()
    {
        SignalBus.Fire<BalloonFlewAwaySignal>(new BalloonFlewAwaySignal(this));
        Dispose();
    }

    public void OnMouseDown()
    {
        SignalBus.Fire<BalloonExplodedSignal>(new BalloonExplodedSignal(this));
        Dispose();
    }

    private void MoveToFlyStartPosition()
    {
        transform.position = new BaloonSpawnPositionGenerator().Generate(this);
    }
}