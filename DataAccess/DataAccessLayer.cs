using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessLayer<T>
    {
        public string path;
        public string fileName;
        public JsonSerializer serializer;

        public DataAccessLayer(string fileName)
        {
            fileName = String.Format("@{0}.json", fileName);
            path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public void WriteAllText(T data)
        {
            string input = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, input);
        }

        public T GetAllData()
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
