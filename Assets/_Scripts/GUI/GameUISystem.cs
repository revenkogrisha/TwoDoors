using TwoDoors.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TwoDoors.GUI
{
    public class GameUISystem : MonoBehaviour
    {
        private const int _menuSceneId = 0;

        [SerializeField] private GameObject _finishPanel;
        [SerializeField] private GameObject _gameOverPanel;

        [Inject] private Score _score;

        #region MonoBehaviour

        private void OnEnable()
        {
            _score.OnGameFinished += OpenFinishPanel;
            _score.OnGameOvered += OpenGameOverPanel;
        }

        private void OnDisable()
        {
            _score.OnGameFinished -= OpenFinishPanel;
            _score.OnGameOvered -= OpenGameOverPanel;
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
