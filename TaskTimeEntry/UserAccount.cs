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
        public string email { get; protected set; }
        public Guid _id { get; protected set; }
        public List<Guid> projects { get; protected set; }        
        public List<Task> tasks { get; protected set; }

        public void AddProject(Project project)
        {
            projects.Add(project._id);
        }

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
            task.AddComment(comment);
        }
    }
}
