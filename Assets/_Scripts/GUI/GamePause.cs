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
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            if (!_isOnPause)
            {
                PauseGame();
            }
            else if (_isOnPause)
            {
                ContinueGame();
            }
        }

        private void PauseGame()
        {
            _pausePanel.SetActive(true);
            _isOnPause = true;
            OnGamePaused?.Invoke();
        }

        private void ContinueGame()
        {
            _pausePanel.SetActive(false);
            _isOnPause = false;
            OnGameContinued?.Invoke();
        }
    }
}
