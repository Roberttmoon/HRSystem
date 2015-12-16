using DataAccess;
using TaskTimeEntry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public static class ModelView
    {
        public static void AddCredentialsToDatabase(BillableAsset asset, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>();
            if (!allCredentials.Exists(item => item.email == asset.email))
            {
                Credentials credentials = new Credentials("asset", asset.email, asset._id, password);
                string json = Serializer<Credentials>.SerializeToJson(credentials);
                mongo.AddDocumentFromJsonString(json);
            } else
            {
                throw new Exception("Credentials Already Exist.");
            }
        }

        public static void AddCredentialsToDatabase(Client client, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>();
            if (!allCredentials.Exists(item => item.email == client.email))
            {
                Credentials credentials = new Credentials("client", client.email, client._id, password);
                string json = Serializer<Credentials>.SerializeToJson(credentials);
                mongo.AddDocumentFromJsonString(json);
            }
            else
            {
                throw new Exception("Credentials Already Exist.");
            }
        }

        public static void AddAssetToDatabase(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>();
            if (!assets.Exists(item => item.email == asset.email))
            {
                string json = Serializer<BillableAsset>.SerializeToJson(asset);
                mongo.AddDocumentFromJsonString(json);
            } else
            {
                throw new Exception("Asset already exists.");
            }
        }

        public static void AddClientToDatabase(Client client)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "clients");
            List<Client> clients = mongo.GetAllDocuments<Client>();
            if (!clients.Exists(item => item.email == client.email))
            {
                string json = Serializer<Client>.SerializeToJson(client);
                mongo.AddDocumentFromJsonString(json);
            } else
            {
                throw new Exception("Client already exists");
            }
        }

        public static bool CheckCredentials(string email, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>();
            Credentials entered = allCredentials.Find(item => item.email == email);
            Trace.WriteLine(entered.email);
            Trace.WriteLine(entered.password);
            if (password == entered.password) return true;
            else return false;
        }

        public static BillableAsset GetAsset(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>();
            BillableAsset searched = assets.Find(item => item.email == email);
            Trace.WriteLine(searched.email);
            return searched;
        }
        public static Client GetClient(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "clients");
            List<Client> client = mongo.GetAllDocuments<Client>();
            return client.Find(item => item.email == email);
        }

        public static List<Client> GetAllClients()
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "clients");
            return mongo.GetAllDocuments<Client>();
        }

        public static List<BillableAsset> GetAllAssets()
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            return mongo.GetAllDocuments<BillableAsset>();
        }

        public static void ReplaceAsset(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            string json = Serializer<BillableAsset>.SerializeToJson(asset);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", asset._id));
        }

        public static void ReplaceClient(Client client)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "clients");
            string json = Serializer<Client>.SerializeToJson(client);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", client._id));
        }

        public static void GetClientThroughFilter(Client client) 
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "clients");
            List<string> json = mongo.QueryTopLevel(new KeyValuePair<string, Guid>("_id", client._id));
            Trace.WriteLine(json.Count);
        }
    }
}
