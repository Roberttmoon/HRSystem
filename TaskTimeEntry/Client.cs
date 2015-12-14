using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Client
    {
        private string clientName;
        private Guid clientID;
        private List<Project> clientProjects;
        private float discount;

        Client()
        {
            clientProjects = new List<Project>();
        }

        public void addTime(Project project, int time)
        {
        }
        public void addProject(Project project, ref List<Project> clientProjects)
        {
            clientProjects.Add(project);
        }

    }
}
