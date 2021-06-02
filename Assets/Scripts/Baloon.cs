using UnityEngine;
using Zenject;

public class Baloon : MonoBehaviour
{
    private SignalBus SignalBus;
    private float StartSpeed;

    [Inject]
    public void Construct(SignalBus signalBus, Settings settings)
    {
        SignalBus = signalBus;
        StartSpeed = settings.BaloonStartSpeed;
    }

    public void Update()
    {
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
        SignalBus.Fire<BaloonFlewAwaySignal>(new BaloonFlewAwaySignal(this));
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        SignalBus.Fire<BaloonExplodedSignal>(new BaloonExplodedSignal(this));
        Destroy(gameObject);
    }
}