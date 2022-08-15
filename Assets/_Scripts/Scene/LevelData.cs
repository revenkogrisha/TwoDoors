using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    public class LevelData
    {
        private const string LastFinishedLevel = nameof(LastFinishedLevel);

        private SaveService _saveService;

        private readonly int _id;

        public LevelData(int id, SaveService save)
        {
            _id = id;
            _saveService = save;
        }

        public void SaveLevel()
        {
            var highestId = PlayerPrefs.GetInt(LastFinishedLevel);
            if (highestId < _id)
            {
                PlayerPrefs.SetInt(LastFinishedLevel, _id);

                _saveService.Save();
                _saveService.Load();
            }
        }
    }
}