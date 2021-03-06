using ExplodeBalloons.Common;
using ExplodeBalloons.Storage;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ExplodeBalloons.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private StringUnityEvent OnEmitBestRecord;

        private IStorage Storage;

        [Inject]
        public void Construct(IStorage storage)
        {
            Storage = storage;
        }

        private void Start()
        {
            EmitBestRecord();
        }

        public void EmitBestRecord()
        {
            OnEmitBestRecord.Invoke(Storage.Get<float>("record").ToString());
        }

        public void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("Game");
        }
    }
}