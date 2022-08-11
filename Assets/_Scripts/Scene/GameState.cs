using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public class GameState : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField, Min(1)] private int _levelId;

        [Inject] private Score _score;
        [Inject] private GamePause _pause;

        private LevelData _levelData;

        #region MonoBehaviour

        private void Awake()
        {
            _levelData = new(_levelId);

            _pause.ContinueTimeFlow();
        }

        private void OnEnable()
        {
            _score.OnGameFinished += FinishLevel;
            _score.OnGameOvered += GameOver;
        }

        private void OnDisable()
        {
            _score.OnGameFinished -= FinishLevel;
            _score.OnGameOvered -= GameOver;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _pause.TryPause();
        }

        #endregion

        private void FinishLevel()
        {
            _pause.StopTimeFlowWithDelay(_pause.PopupDelaySeconds);
            _levelData.SaveLevel();
        }

        private void GameOver()
        {
            _pause.StopTimeFlowWithDelay(_pause.PopupDelaySeconds);
        }
    }
}
