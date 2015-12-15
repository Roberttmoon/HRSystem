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
        public static bool AddCredentialToDatabase(BillableAsset asset, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            //List<Dictionary<Guid, string>> existingCredentials = GetAllCredentials(mongo);
            //foreach(Dictionary<Guid, string> item in existingCredentials)
            //{
            //    if (item.ContainsKey(asset.id))
            //    {
            //        return false;
            //    }
            //}
            Dictionary<Guid, string> credentials = new Dictionary<Guid, string>();
            credentials.Add(asset.id, password);
            mongo.AddDocument(Serializer<Dictionary<Guid, string>>.SerializeToJson(credentials));
            return true;
        }

        public static void AddAssetToDatabase(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            List<BillableAsset> assets = GetAllAssets(mongo);
            bool itemExists = false;
            foreach(BillableAsset item in assets)
            {
                if (item.id == asset.id)
                {
                    itemExists = true;
                }
            }
            if (!itemExists) mongo.AddDocument(Serializer<BillableAsset>.SerializeToJson(asset));
        }

        public static List<BillableAsset> GetAllAssets(MongoAccessLayer mongo)
        {
            List<string> jsonDocs = mongo.GetAllDocuments();
            List<BillableAsset> assets = new List<BillableAsset>();
            foreach(string doc in jsonDocs)
            {
                assets.Add(Serializer<BillableAsset>.DeserializeFromJson(doc));
            }
            return assets;
        }

        public static List<Dictionary<Guid, string>> GetAllCredentials(MongoAccessLayer mongo)
        {
            List<string> jsonDocs = mongo.GetAllDocuments();
            List<Dictionary<Guid, string>> credentials = new List<Dictionary<Guid, string>>();
            foreach (string doc in jsonDocs)
            {
                credentials.Add(Serializer<Dictionary<Guid, string>>.DeserializeFromJson(doc));
            }
            return credentials;
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
    }
}
