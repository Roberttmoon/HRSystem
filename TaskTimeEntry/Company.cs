using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Company
    {
        public List<BillableAsset> assets;
        public List<Client> clients;

        public Company()
        {
            assets = ModelView.GetAllAssets();
            clients = ModelView.GetAllClients();
        }

        public List<Project> GetAllProjects()
        {
            List<Project> allProjects = new List<Project>();
            foreach(Client client in clients)
            {
                foreach(Project project in client.projects)
                {
                    allProjects.Add(project);
                }
            }
            return allProjects;
        }

        public void AddProject(Project project)
        {

        }

        public void AddBillableAsset(BillableAsset asset)
        {

        }
    }
}
