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
        public Guid clientID { get; set;}
        public int billableHoursSigned;
        protected int billableHoursActual;
        protected int hoursRemaining;
        protected bool statusComplete = false;
        protected List<BillableAsset> resources;
        public List<Task> tasks { get; private set; }
        public List<string> comments;

        public Project()
        {
            _id = Guid.NewGuid();
            resources = new List<BillableAsset>();
            tasks = new List<Task>();
            comments = new List<string>();
        }

        public void ChangeStatus(bool status)
        {
            statusComplete = status;
        }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }

        public void AddResource(BillableAsset asset)
        {
            throw new NotImplementedException();
        }

        public void AddBillableHours(int hours)
        {
            throw new NotImplementedException();
        }


    }
}
