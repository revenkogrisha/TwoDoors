using System;
using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    public class RecordScore : Score
    {
        private const string Record = nameof(Record);

        [Inject] private SaveService _saveService;

        public override event Action OnGameOvered;
        public override event Action OnPlayerScored;
        public event Action OnRecordBreaked;

        public override void AddScore()
        {
            base.AddScore();

            OnPlayerScored?.Invoke();
        }

        public override void InitFail()
        {
            var record = _saveService.RecordScore;
            if (Amount > record)
            {
                OnRecordBreaked?.Invoke();

                PlayerPrefs.SetInt(Record, Amount);
                _saveService.Save();
                _saveService.Load();

                return;
            }

            OnGameOvered?.Invoke();
        }
    }
}