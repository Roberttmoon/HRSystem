using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataAccess
{
    public class ProjectData
    {
        public string clientName;
        public Guid clientID;
        public Guid projectID;
        public int billableHoursSigned;
        public int billableHoursActual;
        public int hoursRemaining;
        public bool statusComplete;
        public List<BillableAssetData> resources;
        public List<string> comments;

        public ProjectData()
        {

        }

        public ProjectData(string clientName, Guid clientID, Guid projectID, int hoursSigned, int hoursAct, int hoursRem, bool status, List<BillableAssetData> resources, List<string> comments)
        {
            this.clientName = clientName;
            this.clientID = clientID;
            this.projectID = projectID;
            this.billableHoursSigned = hoursSigned;
            this.billableHoursActual = hoursAct;
            this.hoursRemaining = hoursRem;
            this.statusComplete = status;
            this.resources = resources;
            this.comments = comments;
        }
    }
}
