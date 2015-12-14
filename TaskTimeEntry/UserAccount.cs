using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public abstract class UserAccount
    {
        public string name { get; protected set; }
        public MailAddress email { get; protected set; }
        public Guid id { get; protected set; }
        public Dictionary<Project, List<Task>> work { get; protected set; }

        public void AddTime(Project project, int time)
        {
            throw new NotImplementedException();
        }

        public void AddProject(Project project, ref List<Project> projects)
        {
            projects.Add(project);
        }
    }
}
