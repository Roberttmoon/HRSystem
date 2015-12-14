using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public class BillableAsset : UserAccount
    {
        public float hourlyRate { get; private set; }

        public BillableAsset()
        {

        }
        static public BillableAsset CreateAssit(string name, MailAddress email)
        {
            BillableAsset newAssit = new BillableAsset();
            newAssit.id = Guid.NewGuid();
            newAssit.name = name;
            newAssit.email = email;
            return newAssit;
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
