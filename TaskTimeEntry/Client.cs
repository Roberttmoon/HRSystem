using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Client : UserAccount
    {
        private float discount;

        public Client()
        {

        }

        public void addProject(Project project, ref List<Project> clientProjects)
        {
            clientProjects.Add(project);
        }

    }
}
