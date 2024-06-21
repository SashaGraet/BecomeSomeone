using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace SaveLoadSystem
{
    public class JsonSaveService
    {
        public void Save(object data, string fileName)
        {
            using StreamWriter sw = new StreamWriter(new FileStream(BuildPath(fileName), FileMode.Create));
            string json = JsonConvert.SerializeObject(data);
            sw.Write(json);
        }

        public T Load<T>(string fileName)
        {
            using StreamReader sr = new StreamReader(new FileStream(BuildPath(fileName), FileMode.OpenOrCreate));
            string json = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string BuildPath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }
}