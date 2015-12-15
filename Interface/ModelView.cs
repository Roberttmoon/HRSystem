using DataAccess;
using TaskTimeEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public static class ModelView
    {
        public static void AddCredentialsToFile(string email, string password)
        {
            FileAccessLayer file = new FileAccessLayer("credentials");
            List<Dictionary<string, string>> data = Serializer<List<Dictionary<string, string>>>.DeserializeFromJson(file.GetAllText());
            Dictionary<string, string> credentials = Serializer<string>.CreateDictionary(email, password);
            foreach(Dictionary<string, string> item in data)
            {
                if (!item.ContainsKey(email))
                {
                    data.Add(credentials);
                    string json = Serializer<List<Dictionary<string, string>>>.SerializeToJson(data);
                    file.WriteAllText(json);
                }
            }
        }
    }
}
