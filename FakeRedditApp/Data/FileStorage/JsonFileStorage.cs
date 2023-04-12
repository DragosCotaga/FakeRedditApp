using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace FakeRedditApp.Data.FileStorage
{
    public class JsonFileStorage<T> where T : class
    {
        private readonly string _filePath;

        public JsonFileStorage(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> ReadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                return new List<T>();
            }

            string jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }

        public void WriteToFile(List<T> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, (Newtonsoft.Json.Formatting)Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
