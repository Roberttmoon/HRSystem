using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace TaskTimeEntry
{
    public class BillableAsset : UserAccount
    {
        public float hourlyRate { get; private set; }

        public BillableAsset()
        {

        }

        public BillableAsset CreateAsset(string name, string email)
        {
            BillableAsset newAsset = new BillableAsset();
            id = Guid.NewGuid();
            this.name = name;
            this.email = new MailAddress(email);
            return newAsset;
        }
        

        void AddTaskToTaskList(Task task, ref List<Task> taskList)
        {
            taskList.Add(task);
        }

        public void addProject(Project project, List<Task> task)
        {
            if (this.work.ContainsKey(project))
            {
                work[project] = task;
            }else
            {
                work.Add(project, task);
            }
        }
    }
}
