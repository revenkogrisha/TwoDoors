using System.IO;
using UnityEngine;

namespace TwoDoors.Save
{
    public class JsonSaveSystem : ISaveSystem
    {
        private readonly string _filePath;

        public JsonSaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData data)
        {
            var json = JsonUtility.ToJson(data);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(json);
            }
        }

        public SaveData Load()
        {
            var json = "";

            if (!File.Exists(_filePath))
                return new SaveData();

            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }

                if (string.IsNullOrEmpty(json))
                    return new SaveData();

                return JsonUtility.FromJson<SaveData>(json);
            }
        }
    }
}