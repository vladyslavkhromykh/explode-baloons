using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExplodeBalloons.UI
{
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
}