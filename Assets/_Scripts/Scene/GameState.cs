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
        [SerializeField] private Pause _pause;

        private int _score = 0;

        public event Action OnGameFinished;
        public event Action OnGameOvered;
        public event Action OnCharacterPassed;
        public event Action OnPlayerMistaken;

        #region MonoBehaviour

        private void Awake()
        {
            ContinueGame();
        }

        private void OnEnable()
        {
            _pause.OnGamePaused += PauseGame;
        }

        private void OnDisable()
        {
            _pause.OnGamePaused -= PauseGame;
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
            PauseGame();
            OnGameFinished?.Invoke();

            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(LastFinishedLevel, sceneIndex);
        }

        private void GameOver()
        {
            PauseGame();
            OnGameOvered?.Invoke();
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
        }

        private void ContinueGame()
        {
            Time.timeScale = 1f;
        }
    }
}
