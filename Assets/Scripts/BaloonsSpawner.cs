using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class BaloonsSpawner : ITickable
    {
        private BaloonFactory Factory;
        private float Timer;
        
        public BaloonsSpawner(BaloonFactory factory)
        {
            Factory = factory;
            
            Spawn();
        }
        
        public void Tick()
        {
            Timer += Time.deltaTime;

            if (Timer >= 3.0f)
            {
                Timer = 0.0f;
                Spawn();
            }
        }
        
        public void Spawn()
        {
            Baloon baloon = Factory.Create();
            baloon.transform.position = GetSpawnPosition();
        }

        public Vector3 GetSpawnPosition()
        {
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 0.0f), 0.0f));
            spawnPosition.z = 0.0f;
            return spawnPosition;
        }
    }
}