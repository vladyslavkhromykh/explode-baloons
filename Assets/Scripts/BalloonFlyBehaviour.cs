using UnityEngine;
using Zenject;

public class BalloonFlyBehaviour : ITickable
{
    private BalloonModel BalloonModel;
    private BalloonView BalloonView;

    public BalloonFlyBehaviour(BalloonModel balloonModel, BalloonView balloonView)
    {
        BalloonModel = balloonModel;
        BalloonView = balloonView;
    }

    public void Tick()
    {
        if (!BalloonModel.IsAlive)
        {
            return;
        }

        Fly();
    }

    private void Fly()
    {
        BalloonModel.Position.y += BalloonModel.Speed * Time.deltaTime;
    }
}