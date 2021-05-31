using System;
using Zenject;

public class LoseConditionChecker : IInitializable, IDisposable
{
    private SignalBus SignalBus;
    private int FlewAwayBaloonsCounter;
    
    public LoseConditionChecker(SignalBus signalBus)
    {
        SignalBus = signalBus;
    }
    
    public void Initialize()
    {
        SignalBus.Subscribe<BaloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
    }

    public void Dispose()
    {
        SignalBus.Unsubscribe<BaloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
    }
    
    private void OnBaloonFlewAwaySignal(BaloonFlewAwaySignal signal)
    {
        FlewAwayBaloonsCounter++;
        if (FlewAwayBaloonsCounter >= 5)
        {
            SignalBus.Fire<SessionEndSignal>();
            SignalBus.Fire<LoseGameSignal>();
        }
    }
}