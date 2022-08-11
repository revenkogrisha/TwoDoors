using System;
using TwoDoors.GUI;
using UnityEngine;

namespace TwoDoors.Scene
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private Panel _pausePanel;

        private bool _isOnPause = false;

        public event Action OnGamePaused;
        public event Action OnGameContinued;

        public float PopupDelaySeconds = 0.6f;

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

        public void StopTimeFlowWithDelay(float delay)
        {
            Invoke(nameof(StopTimeFlow), delay);
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
            StopTimeFlowWithDelay(PopupDelaySeconds);
            _pausePanel.Show();
            _isOnPause = true;

            OnGamePaused?.Invoke();
        }

        private void ContinueGame()
        {
            ContinueTimeFlow();
            _pausePanel.Close();
            _isOnPause = false;

            OnGameContinued?.Invoke();
        }
    }
}
