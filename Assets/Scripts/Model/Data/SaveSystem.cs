using System.IO;
using UnityEngine;

namespace Model.Data
{
    public class SaveSystem<TPropertyType> where TPropertyType : new()
    {
        private readonly string _filePath;

        public SaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData<TPropertyType> data)
        {
            var json = JsonUtility.ToJson(data);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(json);
            }
        }

        public SaveData<TPropertyType> Load()
        {
            var json = string.Empty;

            if (!File.Exists(_filePath))
                return new SaveData<TPropertyType>();

            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }

            if (string.IsNullOrEmpty(json))
                return new SaveData<TPropertyType>();

            return JsonUtility.FromJson<SaveData<TPropertyType>>(json);
        }
    }
}