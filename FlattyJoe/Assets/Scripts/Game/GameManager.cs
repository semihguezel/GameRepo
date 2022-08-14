using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    
        public void LoadTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }
        public void HighScoreTable()
        {
            SceneManager.LoadScene("HighScoreTable");
        }

        public void ReturnMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    
        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
