using System;
using UnityEngine;

namespace TwoDoors.Scene
{
    public class GamePause
    {
        private readonly GameObject _pausePanel;
        private bool _isOnPause = false;

        public event Action OnGamePaused;
        public event Action OnGameContinued;

        public GamePause(GameObject pausePanel)
        {
            _pausePanel = pausePanel;
        }

        public void TryPause()
        {
            if (!_isOnPause)
            {
                PauseGame();
            }
            else if (_isOnPause)
            {
                ContinueGame();
            }
        }

        public void StopTimeFlow()
        {
            Time.timeScale = 0f;
        }

        public void ContinueTimeFlow()
        {
            Time.timeScale = 1f;
        }

        private void PauseGame()
        {
            StopTimeFlow();
            ShowPausePanel();
            OnGamePaused?.Invoke();
        }

        private void ContinueGame()
        {
            ContinueTimeFlow();
            ClosePausePanel();
            OnGameContinued?.Invoke();
        }

        private void ShowPausePanel()
        {
            _pausePanel.SetActive(true);
            _isOnPause = true;
        }

        private void ClosePausePanel()
        {
            _pausePanel.SetActive(false);
            _isOnPause = false;
        }
    }
}
