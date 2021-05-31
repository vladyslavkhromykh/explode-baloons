using UnityEngine;
using Zenject;

public class SessionStarter : MonoBehaviour
{
    private SignalBus SignalBus;
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        Debug.LogError("SessionStarter.Construct");
        SignalBus = signalBus;
    }

    private void Start()
    {
        SignalBus.Fire<SessionStartSignal>();
    }
}