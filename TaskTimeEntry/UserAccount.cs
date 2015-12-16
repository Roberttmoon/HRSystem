using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public abstract class UserAccount
    {
        public string name { get; set; }
        public string email { get; protected set; }
        public Guid _id { get; protected set; }
        public bool privilege { get; set; }
        public List<Project> projects { get; protected set; }

        public void AddProject(Project project)
        {
            projects.Add(project);
        }


        public void ReplaceProject(Guid projectID, Project newProject)
        {
            Project projectToReplace = projects.Find(item => item._id == projectID);
            int replaceIndex = projects.IndexOf(projectToReplace);
            projects[replaceIndex] = newProject;
        }

        public int LogTime(Task task, float time, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
