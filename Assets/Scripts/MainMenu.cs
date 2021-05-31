using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private StringUnityEvent OnEmitBestRecord;

    private IStorage Storage;

    [Inject]
    public void Construct(IStorage storage)
    {
        Debug.LogError("Construct");
        Storage = storage;
    }

    private void Start()
    {
        EmitBestRecord();
    }

    public void EmitBestRecord()
    {
        Storage.Get<float>("some");
        OnEmitBestRecord.Invoke(Storage.Get<float>("record").ToString());
    }
    
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}