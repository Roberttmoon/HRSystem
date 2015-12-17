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
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>("credentials");
            if (!allCredentials.Exists(item => item.email == asset.email))
            {
                Credentials credentials = new Credentials("asset", asset.email, asset._id, password);
                string json = Serializer<Credentials>.SerializeToJson(credentials);
                mongo.AddDocumentFromJsonString(json, "credentials");
            }
            else
            {
               // throw new Exception("Credentials Already Exist.");
            }
        }

        public static void AddCredentialsToDatabase(Client client, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>("credentials");
            if (!allCredentials.Exists(item => item.email == client.email))
            {
                Credentials credentials = new Credentials("client", client.email, client._id, password);
                string json = Serializer<Credentials>.SerializeToJson(credentials);
                mongo.AddDocumentFromJsonString(json, "credentials");
            }
            else
            {
                //return false;
                //throw new Exception("Credentials Already Exist.");
            }
        }

        public static void AddAssetToDatabase(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>("assets");
            if (!assets.Exists(item => item.email == asset.email))
            {
                string json = Serializer<BillableAsset>.SerializeToJson(asset);
                mongo.AddDocumentFromJsonString(json, "assets");
            }
            else
            {
                //throw new Exception("Asset already exists.");
            }
        }

        public static void AddClientToDatabase(Client client)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Client> clients = mongo.GetAllDocuments<Client>("clients");
            if (!clients.Exists(item => item.email == client.email))
            {
                string json = Serializer<Client>.SerializeToJson(client);
                mongo.AddDocumentFromJsonString(json, "clients");
            }
            else
            {
                //throw new Exception("Client already exists");
            }
        }

        public static bool CheckCredentials(string email, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>("credentials");
            Credentials entered = allCredentials.Find(item => item.email == email);
            if (password == entered.password) return true;
            else return false;
        }

        public static BillableAsset GetAsset(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>("assets");
            BillableAsset searched = assets.Find(item => item.email == email);
            Trace.WriteLine(searched.email);
            return searched;
        }
        public static Client GetClient(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Client> client = mongo.GetAllDocuments<Client>("clients");
            return client.Find(item => item.email == email);
        }

        public static Client GetClient(Guid id)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Client> client = mongo.GetAllDocuments<Client>("clients");
            return client.Find(item => item._id == id);
        }

        public static void StoreClient(Client client, MongoAccessLayer mongo)
        {
            string json = Serializer<Client>.SerializeToJson(client);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", client._id), "clients");
        }

        public static void StoreAsset(BillableAsset asset, MongoAccessLayer mongo)
        {
            string json = Serializer<BillableAsset>.SerializeToJson(asset);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", asset._id), "assets");
        }

        public static List<Client> GetAllClients()
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            return mongo.GetAllDocuments<Client>("clients");
        }

        public static List<BillableAsset> GetAllAssets()
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            return mongo.GetAllDocuments<BillableAsset>("assets");
        }

        public static void ReplaceAsset(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            string json = Serializer<BillableAsset>.SerializeToJson(asset);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", asset._id), "assets");
        }

        public static void UpdateClientWithProject(Project project, Client client)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            project.clientID = client._id;
            client.AddProject(project);
            StoreClient(client, mongo);
        }

        public static void UpdateProjectWithTask(Client client, Project project, Task task)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            project.AddTask(task);
            client.ReplaceProject(project._id, project);
            StoreClient(client, mongo);
        }

        public static void UpdateProjectWithAsset(Project project, BillableAsset asset)
        {
            MongoAccessLayer mongoClient = new MongoAccessLayer("main");
            Client client = GetClient(project.clientID);
            project.AddResource(asset._id);
            client.ReplaceProject(project._id, project);
            StoreClient(client, mongoClient);
            UpdateAssetsWithProjects();
        }

        public static void UpdateAssetsWithProjects()
        {
            MongoAccessLayer mongoAssets = new MongoAccessLayer("main");
            List<BillableAsset> assets = GetAllAssets();
            foreach(BillableAsset asset in assets)
            {
                asset.PopulateProjects();
                string json = Serializer<BillableAsset>.SerializeToJson(asset);
                mongoAssets.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", asset._id), "assets");
            }
        }
    }
}
