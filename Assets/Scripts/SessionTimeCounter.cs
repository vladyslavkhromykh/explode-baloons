using UnityEngine;
using Zenject;

public class BestRecordHandler
{
    private IStorage Storage;
    private SignalBus SignalBus;
    private float SessionStartTime;
    
    public BestRecordHandler(SignalBus signalBus, IStorage storage)
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
        float sessionLength = Time.time - SessionStartTime;
        float previousRecord = Storage.Get<float>("record");
        if (sessionLength > previousRecord)
        {
            Storage.Save("record", sessionLength);
        }
        
    }
}