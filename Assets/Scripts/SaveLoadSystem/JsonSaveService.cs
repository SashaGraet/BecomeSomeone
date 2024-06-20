using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace SaveLoadSystem
{
    public class JsonSaveService
    {
        public void Save(object data, string fileName)
        {
            using StreamWriter sw = new StreamWriter(new FileStream(BuildPath(fileName), FileMode.OpenOrCreate));
            string json = JsonConvert.SerializeObject(data);
            Debug.Log(json);
            sw.Write(json);
        }

        public T Load<T>(string fileName)
        {
            using StreamReader sr = new StreamReader(new FileStream(BuildPath(fileName), FileMode.OpenOrCreate));
            string json = sr.ReadToEnd();
            Debug.Log(json);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string BuildPath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }
}