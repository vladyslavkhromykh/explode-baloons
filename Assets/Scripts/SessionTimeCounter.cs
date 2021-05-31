using UnityEngine;
using Zenject;

public class SessionTimeCounter
{
    private IStorage Storage;
    private SignalBus SignalBus;
    private float SessionStartTime;

    public SessionTimeCounter(SignalBus signalBus, IStorage storage)
    {
        SignalBus = signalBus;
        Storage = storage;
        
        SignalBus.Subscribe<SessionStartSignal>(OnSessionStartSignal);
        SignalBus.Subscribe<SessionEndSignal>(OnSessionEndSignal);
    }

    private void OnSessionStartSignal()
    {
        SessionStartTime = Time.time;
    }
    
    private void OnSessionEndSignal()
    {
        float SessionLength = Time.time - SessionStartTime;
        Storage.Save("record", SessionLength);
    }
}