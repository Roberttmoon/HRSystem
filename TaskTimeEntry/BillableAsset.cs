using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace TaskTimeEntry
{
    [Serializable]
    public class BillableAsset : UserAccount
    {
        public float hourlyRate { get; private set; }

        public BillableAsset(string name, string email)
        {
            this.name = name;
            this.email = email;
            _id = Guid.NewGuid();
            projects = new List<Project>();
        }

        void AddTaskToTaskList(Task task, ref List<Task> taskList)
        {
            taskList.Add(task);
        }

        public void addProject(Project project, List<Task> task)
        {
            throw new NotImplementedException();
        }
    }
}
