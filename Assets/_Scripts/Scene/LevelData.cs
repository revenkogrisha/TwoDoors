using UnityEngine;

namespace TwoDoors.Scene
{
    public class LevelData
    {
        private const string LastFinishedLevel = nameof(LastFinishedLevel);

        private readonly int _id;

        public LevelData(int id)
        {
            _id = id;
        }

        public void SaveLevel() => PlayerPrefs.SetInt(LastFinishedLevel, _id);
    }
}