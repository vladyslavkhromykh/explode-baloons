using System;
using UnityEngine.SceneManagement;
using Zenject;

public class LoseGameProcessor : IInitializable, IDisposable
{
    private SignalBus SignalBus;

    public LoseGameProcessor(SignalBus signalBus)
    {
        SignalBus = signalBus;
    }

    public void Initialize()
    {
        SignalBus.Subscribe<LoseGameSignal>(OnLoseGameSignal);
    }

    public void Dispose()
    {
        SignalBus.Unsubscribe<LoseGameSignal>(OnLoseGameSignal);
    }

    private void OnLoseGameSignal(LoseGameSignal signal)
    {
        SceneManager.LoadScene("LoseMenu");
    }
}