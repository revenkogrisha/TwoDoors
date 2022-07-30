using TwoDoors.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDoors.Scene
{
    public class GameState : MonoBehaviour
    {
        private const string LastFinishedLevel = nameof(LastFinishedLevel);

        [SerializeField] private int _defaultReward = 1;
        [SerializeField] private int _defaultPunishment = 2;

        private int _score = 0;

        #region MonoBehaviour

        private void Awake()
        {
            Time.timeScale = 1;
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

            EventHolder.RaiseCharacterPassed();
        }

        public void SubtractScore()
        {
            _score -= _defaultPunishment;

            if (_score < 0)
            {
                GameOver();
                return;
            }

            EventHolder.RaisePlayerMistaken();
        }

        private void FinishLevel()
        {
            Time.timeScale = 0;

            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt(LastFinishedLevel, sceneIndex);

            EventHolder.RaiseGameFinish();
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            EventHolder.RaiseGameOver();
        }
    }
}
