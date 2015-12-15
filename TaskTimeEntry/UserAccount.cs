using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public abstract class UserAccount : ITaskInteract
    {
        public string name { get; protected set; }
        public MailAddress email { get; protected set; }
        public Guid id { get; protected set; }
        public List<Dictionary<Project, List<Task>>> work { get; protected set; }

        public int LogTime(Task task, float time, string comment)
        {
            throw new NotImplementedException();
        }

        public void CloseTask(Task task)
        {
            task.ChangeStatus(true);
        }

        public void AddComment(Task task, string comment)
        {
            task.AddComment(DateTime.Now, comment);
        }

        public void AddProject(Project project, ref List<Project> projects)
        {
            projects.Add(project);
        }

        public string GetProject()
        {
            throw new NotImplementedException();
        }
    }

}
