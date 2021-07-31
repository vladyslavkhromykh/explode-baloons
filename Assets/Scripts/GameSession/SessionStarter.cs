using ExplodeBalloons.Signals;
using UnityEngine;
using Zenject;

namespace ExplodeBalloons.GameSession
{
    public class SessionStarter : MonoBehaviour
    {
        private SignalBus SignalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        private void Start()
        {
            SignalBus.Fire<SessionStartSignal>();
        }
    }
}