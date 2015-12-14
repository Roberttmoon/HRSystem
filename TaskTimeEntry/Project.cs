using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Project
    {
        protected string clientName;
        protected Guid clientID;
        protected Guid projectID;
        protected int billableHoursSigned;
        protected int billableHoursActual;
        protected int hoursRemaining;
        protected bool statusComplete;
        protected List<BillableAsset> resources;
        protected List<string> comments;

        public Project()
        {

        }

        public AddResource(BillableAsset asset)
        {
            throw new NotImplementedException();
        }

        public AddBillableHours(int hours)
        {
            throw new NotImplementedException();
        }
    }
}
