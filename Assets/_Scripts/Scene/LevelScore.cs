using System;
using UnityEngine;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public class LevelScore : Score
    {
        [SerializeField] private int _defaultPunishment = 2;
        [SerializeField] private int _winScore = 10;
        [SerializeField] private int _loseScore = 0;

        public event Action OnGameFinished;
        public override event Action OnGameOvered;
        public override event Action OnPlayerScored;
        public event Action OnPlayerFailed;

        public override void AddScore()
        {
            base.AddScore();

            if (Amount >= _winScore)
            {
                OnGameFinished?.Invoke();
                return;
            }

            OnPlayerScored?.Invoke();
        }

        public override void InitFail()
        {
            Amount -= _defaultPunishment;

            if (Amount <= _loseScore)
            {
                OnGameOvered?.Invoke();
                return;
            }

            OnPlayerFailed?.Invoke();
        }
    }
}