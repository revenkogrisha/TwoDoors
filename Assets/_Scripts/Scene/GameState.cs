using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TwoDoors.Scene
{
    public class GameState : MonoBehaviour
    {
        private const string LastFinishedLevel = nameof(LastFinishedLevel);

        [SerializeField] private GameObject _pausePanel;

        [Inject] private Score _score;

        public GamePause Pause { get; private set; }

        #region MonoBehaviour

        private void Awake()
        {
            Pause ??= new(_pausePanel);

            Pause.ContinueTimeFlow();
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
                Pause.TryPause();
        }

        #endregion

        private void FinishLevel()
        {
            Pause.StopTimeFlow();

            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(LastFinishedLevel, sceneIndex);
        }

        private void GameOver()
        {
            Pause.StopTimeFlow();
        }
    }
}
