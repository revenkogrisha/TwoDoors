﻿using System;
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

        public override void AddScore()
        {
            base.AddScore();

            OnPlayerScored?.Invoke();
        }

        public override void InitFail()
        {
            OnGameOvered?.Invoke();

            var record = _saveService.RecordScore;
            if (Amount > record)
            {
                PlayerPrefs.SetInt(Record, Amount);
                _saveService.Save();
                _saveService.Load();
            }
        }
    }
}