using TwoDoors.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TwoDoors.GUI
{
    [DisallowMultipleComponent]
    public class GameUISystem : MonoBehaviour
    {
        private const int _menuSceneId = 0;
        private const string Opened = nameof(Opened);

        [SerializeField] private GameObject _finishPanel;
        [SerializeField] private GameObject _gameOverPanel;

        [Inject] private Score _score;

        private int _openedId;

        #region MonoBehaviour

        private void Awake()
        {
            _openedId = Animator.StringToHash(Opened);
        }

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
            _finishPanel.GetComponent<Animator>().SetTrigger(_openedId);
        }

        public void OpenGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
            _finishPanel.GetComponent<Animator>().SetTrigger(_openedId);
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
