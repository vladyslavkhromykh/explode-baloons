using System;
using Zenject;

public class LoseConditionChecker : IInitializable, IDisposable
{
    private SignalBus SignalBus;
    private int FlewAwayBaloonsCounter;
    private int BaloonsFlewAwayToLoseGame;
    
    public LoseConditionChecker(SignalBus signalBus, Settings settings)
    {
        SignalBus = signalBus;
        BaloonsFlewAwayToLoseGame = settings.BaloonsFlewAwayToLoseGame;
    }
    
    public void Initialize()
    {
        SignalBus.Subscribe<BalloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
    }

    public void Dispose()
    {
        SignalBus.Unsubscribe<BalloonFlewAwaySignal>(OnBaloonFlewAwaySignal);
    }
    
    private void OnBaloonFlewAwaySignal(BalloonFlewAwaySignal signal)
    {
        FlewAwayBaloonsCounter++;
        if (FlewAwayBaloonsCounter >= BaloonsFlewAwayToLoseGame)
        {
            SignalBus.Fire<SessionEndSignal>();
            SignalBus.Fire<LoseGameSignal>();
        }
    }
}