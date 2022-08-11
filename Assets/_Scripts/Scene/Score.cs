using System;
using UnityEngine;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public class Score : MonoBehaviour
    {
        [SerializeField] private int _defaultReward = 1;
        [SerializeField] private int _defaultPunishment = 2;
        [SerializeField] private int _winScore = 10;
        [SerializeField] private int _loseScore = 0;

        private int _score;

        public event Action OnGameFinished;
        public event Action OnGameOvered;
        public event Action OnCharacterPassed;
        public event Action OnPlayerMistaken;

        public void AddScore()
        {
            _score += _defaultReward;

            if (_score >= _winScore)
            {
                OnGameFinished?.Invoke();
                return;
            }

            OnCharacterPassed?.Invoke();
        }

        public void SubtractScore()
        {
            _score -= _defaultPunishment;

            if (_score <= _loseScore)
            {
                OnGameOvered?.Invoke();
                return;
            }

            OnPlayerMistaken?.Invoke();
        }
    }
}