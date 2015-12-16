using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public class Project
    {
        public string projectName { get; set; }
        public Guid _id { get; private set; }
        public Guid clientID { get; set; }
        public int billableHoursSigned { get; set; }
        public int billableHoursActual { get; set; }
        public bool statusComplete { get; set; }
        public List<Guid> resources { get; private set; }
        public List<Task> tasks { get; private set; }
        public List<string> comments { get; private set; }

        public Project()
        {
            _id = Guid.NewGuid();
            resources = new List<Guid>();
            tasks = new List<Task>();
            comments = new List<string>();
            billableHoursActual = 0;
            statusComplete = false;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }

        public void AddResource(Guid assetID)
        {
            resources.Add(assetID);
        }

        public void AddBillableHours(int hours)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(bool status)
        {
            statusComplete = status;
        }
    }
}
