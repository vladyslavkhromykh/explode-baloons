using UnityEngine;

public class BaloonSpawnPositionGenerator
{
    public Vector3 Generate(Balloon balloon)
    {
        Vector3 spawnPosition =
            Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 0.0f), 0.0f));
        spawnPosition.y -= balloon.GetSize().y;
        spawnPosition.z = 0.0f;
        return spawnPosition;
    }
}