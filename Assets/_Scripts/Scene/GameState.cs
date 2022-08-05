using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDoors.Scene
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance;

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
            Pause = new(_pausePanel);

            if (Instance == null)
                Instance = this;
            else if (Instance != null
                && Instance != this)
                throw new Exception($"Singleton initialize exception in {gameObject.name}!");

            ContinueGame();
        }

        private void OnEnable()
        {
            Pause.OnGamePaused += PauseGame;
            Pause.OnGameContinued += ContinueGame;
        }

        private void OnDisable()
        {
            Pause.OnGamePaused -= PauseGame;
            Pause.OnGameContinued -= ContinueGame;
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
