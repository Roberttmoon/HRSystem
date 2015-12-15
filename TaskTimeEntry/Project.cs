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
        public string projectName { get; private set; } // Need
        protected Guid projectID; 
        protected string clientName; // Need
        protected Guid clientID;
        protected int billableHoursSigned; // Need 
        protected int billableHoursActual;
        protected int hoursRemaining;
        protected bool statusComplete;
        protected List<BillableAsset> resources;
        public List<Task> tasks { get; private set; }
        protected List<Dictionary<DateTime, string>> comments;

        public Project()
        {

        }

        public void ChangeStatus(bool status)
        {
            statusComplete = status;
        }

        public void AddComment(DateTime date, string comment)
        {
            Dictionary<DateTime, string> newComment = new Dictionary<DateTime, string>();
            newComment.Add(date, comment);
            comments.Add(newComment);
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
