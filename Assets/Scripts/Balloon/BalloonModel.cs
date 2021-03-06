using ExplodeBalloons.Common;
using UnityEngine;

namespace ExplodeBalloons.Balloon
{
    public class BalloonModel
    {
        public bool IsAlive;
        public float Speed;
        public Vector3 Position;

        public BalloonModel(Settings settings)
        {
            Speed = settings.BaloonStartSpeed;
        }
    }
}