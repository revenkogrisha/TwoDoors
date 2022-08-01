using TwoDoors.Data;
using TwoDoors.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDoors.UI
{
    public class GameUISystem : MonoBehaviour
    {
        private const int _menuSceneId = 0;

        [SerializeField] private GameState _game;
        [SerializeField] private GameObject _finishPanel;
        [SerializeField] private GameObject _gameOverPanel;

        #region MonoBehaviour

        private void OnEnable()
        {
            _game.OnGameFinished += OpenFinishPanel;
            _game.OnGameOvered += OpenGameOverPanel;
        }

        private void OnDisable()
        {
            _game.OnGameFinished -= OpenFinishPanel;
            _game.OnGameOvered -= OpenGameOverPanel;
        }

        #endregion

        public void OpenFinishPanel()
        {
            _finishPanel.SetActive(true);
        }

        public void OpenGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(_menuSceneId);
        }

        public void RestartLevel()
        {
            var thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(thisSceneIndex);
        }
    }
}
