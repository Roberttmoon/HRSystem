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
        public List<Project> projects;

        public Company()
        {
            assets = ModelView.GetAllAssets();
            clients = ModelView.GetAllClients();
            projects = ModelView.GetAllProjects();
        }

        public void AddProject(Project project)
        {

        }

        public void AddBillableAsset(BillableAsset asset)
        {

        }
    }
}
