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
        }

    }
}