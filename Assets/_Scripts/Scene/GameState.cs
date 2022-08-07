using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDoors.Scene
{
    public class GameState : MonoBehaviour
    {
        private const string LastFinishedLevel = nameof(LastFinishedLevel);

        [SerializeField] private int _defaultReward = 1;
        [SerializeField] private int _defaultPunishment = 2;
        [SerializeField] private GameObject _pausePanel;

        private int _score = 0;

        public event Action OnGameFinished;
        public event Action OnGameOvered;
        public event Action OnCharacterPassed;
        public event Action OnPlayerMistaken;

        public GamePause Pause { get; private set; }

        #region MonoBehaviour

        private void Awake()
        {
            Pause ??= new(_pausePanel);

            Pause.ContinueTimeFlow();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause.TryPause();
        }

        #endregion

        public void AddScore()
        {
            _score += _defaultReward;

            if (_score >= 10)
            {
                FinishLevel();
                return;
            }

            OnCharacterPassed?.Invoke();
        }

        public void SubtractScore()
        {
            _score -= _defaultPunishment;

            if (_score < 0)
            {
                GameOver();
                return;
            }

            OnPlayerMistaken?.Invoke();
        }

        private void FinishLevel()
        {
            Pause.StopTimeFlow();
            OnGameFinished?.Invoke();

            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(LastFinishedLevel, sceneIndex);
        }

        private void GameOver()
        {
            Pause.StopTimeFlow();
            OnGameOvered?.Invoke();
        }
    }
}
