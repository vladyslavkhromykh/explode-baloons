using UnityEngine;

namespace ExplodeBalloons.Balloon
{
    public class BaloonSpawnPositionGenerator
    {
        public Vector3 Generate(BalloonView balloonView)
        {
            Vector3 spawnPosition =
                Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 0.0f), 0.0f));
            spawnPosition.y -= balloonView.GetSize().y;
            spawnPosition.z = 0.0f;
            return spawnPosition;
        }
    }
}