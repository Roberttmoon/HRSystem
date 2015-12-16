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
        public static void AddCredentialsToDatabase(BillableAsset asset, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            Credentials credentials = new Credentials(asset.email, asset.id, password);
            string json = Serializer<Credentials>.SerializeToJson(credentials);
            mongo.AddDocumentFromJsonString(json);
        }

        public static void AddAssetToDatabase(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            string json = Serializer<BillableAsset>.SerializeToJson(asset);
            mongo.AddDocumentFromJsonString(json);
        }
    }
}
