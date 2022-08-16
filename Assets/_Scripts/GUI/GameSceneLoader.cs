using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDoors.GUI
{
    public class GameSceneLoader
    {
        private const int _menuSceneIndex = 0;

        public void BackToMenu()
        {
            SceneManager.LoadScene(_menuSceneIndex);
        }

        public void RestartLevel()
        {
            var thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(thisSceneIndex);
        }
    }
}