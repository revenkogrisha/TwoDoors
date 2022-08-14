using UnityEngine;
using UnityEngine.Audio;

namespace TwoDoors.Save
{
    public class SaveService : MonoBehaviour
    {
        private const string Record = nameof(Record);

        [SerializeField] private AudioMixerGroup _mixer;

        private ISaveSystem _saveSystem;

        public int LastFinishedLevel { get; private set; }
        public int RecordScore { get; private set; }
        public float MusicVolume { get; private set; }

        #region MonoBehaviour

        private void Awake()
        {
            _saveSystem = new JsonSaveSystem();

            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        #endregion

        public void Save()
        {
            var data = new SaveData();

            data.LastLevelId = PlayerPrefs.GetInt(nameof(LastFinishedLevel));
            data.Record = PlayerPrefs.GetInt(Record, 0);
            _mixer.audioMixer.GetFloat(
                nameof(MusicVolume), 
                out data.MusicVolume
                );

            _saveSystem.Save(data);
        }

        public void Load()
        {
            var data = _saveSystem.Load();

            LastFinishedLevel = data.LastLevelId;
            RecordScore = data.Record;
            MusicVolume = data.MusicVolume;
        }

        public void ResetProcess()
        {
            _saveSystem.Save(new SaveData());
            Load();
        }
    }
}