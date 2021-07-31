using UnityEngine;
using Zenject;

public class BalloonCameraLimitsChecker : ITickable
{
    private BalloonView BalloonView;
    private SignalBus SignalBus;

    public BalloonCameraLimitsChecker(BalloonView balloonView, SignalBus signalBus)
    {
        BalloonView = balloonView;
        SignalBus = signalBus;
    }

    private void CheckCameraLimits()
    {
        Vector3 topLimit = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, 0.0f));

        Vector3 position = BalloonView.transform.position;
        position.y -= BalloonView.GetSize().y * 0.5f;

        if (position.y > topLimit.y)
        {
            SignalBus.Fire<BalloonFlewAwaySignal>(new BalloonFlewAwaySignal());
            BalloonView.Dispose();
        }
    }

    public void Tick()
    {
        CheckCameraLimits();
    }
}