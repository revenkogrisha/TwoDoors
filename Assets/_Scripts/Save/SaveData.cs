using System;

namespace TwoDoors.Save
{
    [Serializable]
    public class SaveData
    {
        public int LastLevelId = 0;
        public int Record = 0;
        public float MusicVolume = -30f;
    }
}
