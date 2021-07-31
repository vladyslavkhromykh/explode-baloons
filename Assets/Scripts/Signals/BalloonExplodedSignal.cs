using ExplodeBalloons.Balloon;

namespace ExplodeBalloons.Signals
{
    public class BalloonExplodedSignal
    {
        public BalloonModel BalloonModel;

        public BalloonExplodedSignal(BalloonModel balloonModel)
        {
            BalloonModel = balloonModel;
        }
    }
}