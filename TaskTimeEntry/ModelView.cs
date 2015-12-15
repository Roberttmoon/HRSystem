using DataAccess;
using TaskTimeEntry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static bool CheckCredentials(string email, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("Main", "Credential");
            List<string> jsonDocs = mongo.GetAllDocuments();
            foreach(string doc in jsonDocs)
            {
                Trace.WriteLine(doc);
            }
            throw new NotImplementedException();
        }

        public static BillableAsset GetAsset(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("Main", "Assets");
            List<string> jsonDocs = mongo.GetAllDocuments();
            foreach(string doc in jsonDocs)
            {
                Trace.WriteLine(doc);
            }
            throw new NotImplementedException();
        }
    }
}
