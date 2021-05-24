using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
