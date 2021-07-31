using UnityEngine;
using Zenject;

public class BalloonAccelerator : ITickable
{
    public BalloonModel BalloonModel;
    
    public BalloonAccelerator(BalloonModel balloonModel)
    {
        BalloonModel = balloonModel;
    }
    
    public void Tick()
    {
        if (!BalloonModel.IsAlive)
        {
            return;
        }

        Accelerate();
    }
    
    private void Accelerate()
    {
        BalloonModel.Speed += Time.deltaTime;
    }
}