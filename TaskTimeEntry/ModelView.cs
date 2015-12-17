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
        public static bool CheckCredentials(string email, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>("credentials");
            Credentials entered = allCredentials.Find(item => item.email == email);
            if (password == entered.password) return true;
            else return false;
        }

        #region Add To Database
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

        public static void AddProjectToDatabase(Project project)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Project> projects = mongo.GetAllDocuments<Project>("projects");
            if (!projects.Exists(item => item._id == project._id))
            {
                string json = Serializer<Project>.SerializeToJson(project);
                mongo.AddDocumentFromJsonString(json, "projects");
            }
        }

        public static void AddTaskToDatabase(Task task)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Task> tasks = mongo.GetAllDocuments<Task>("tasks");
            if (!tasks.Exists(item => item._id == task._id))
            {
                string json = Serializer<Task>.SerializeToJson(task);
                mongo.AddDocumentFromJsonString(json, "tasks");
            }
        }
        #endregion

        #region Get Items from Database
        public static BillableAsset GetAsset(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>("assets");
            return assets.Find(item => item.email == email);
        }

        public static BillableAsset GetAsset(Guid id)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>("assets");
            return assets.Find(item => item._id == id);

        }

        public static Project GetProject(string projectName)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Project> projects = mongo.GetAllDocuments<Project>("projects");
            return projects.Find(item => item.projectName == projectName);
        }

        public static Project GetProject(Guid id)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Project> projects = mongo.GetAllDocuments<Project>("projects");
            return projects.Find(item => item._id == id);
        }

        public static List<Project> GetProjectsByAsset(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Project> projects = mongo.GetAllDocuments<Project>("projects");
            List<Project> output = new List<Project>();
            foreach(Project project in projects)
            {
                foreach(Guid id in project.resources)
                {
                    if (asset._id == id) output.Add(project);
                }
            }
            return output;
        }

        public static List<Task> GetTasksByProject(Project project)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            List<Task> tasks = mongo.GetAllDocuments<Task>("tasks");
            List<Task> output = new List<Task>();
            foreach(Task task in tasks)
            {
                if (task.projectID == project._id) output.Add(task);
            }
            return output;
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

        public static List<Project> GetAllProjects()
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            return mongo.GetAllDocuments<Project>("projects");
        }
        #endregion

        #region Store Items in Database
        public static void StoreClient(Client client)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            string json = Serializer<Client>.SerializeToJson(client);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", client._id), "clients");
        }

        public static void StoreProject(Project project)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            string json = Serializer<Project>.SerializeToJson(project);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", project._id), "projects");
        }

        public static void StoreAsset(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            string json = Serializer<BillableAsset>.SerializeToJson(asset);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", asset._id), "assets");
        }

        public static void StoreTask(Task task)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main");
            string json = Serializer<Task>.SerializeToJson(task);
            mongo.ReplaceDocument(json, new KeyValuePair<string, Guid>("_id", task._id), "tasks");
        }
        #endregion

        #region Update Objects
        public static void UpdateClientWithProject(Project project, Client client)
        {
            client.AddProject(project._id);
            StoreClient(client);
        }

        public static void UpdateProjectWithTask(Project project, Task task)
        {
            project.AddTask(task._id);
            StoreProject(project);
        }

        public static void UpdateProjectWithAsset(Project project, BillableAsset asset)
        {
            project.AddResource(asset._id);
            asset.AddProject(project._id);
            StoreProject(project);
            StoreAsset(asset);
        }
        #endregion
    }
}
