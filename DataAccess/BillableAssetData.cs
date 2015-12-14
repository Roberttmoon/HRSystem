using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillableAssetData
    {
        public string resourceName { get; set; }
        public MailAddress resourceEmail { get; set; }
        public Guid resourceID { get; set; }
        public Dictionary<ProjectData, List<TaskData>> resourceWork { get; set; }

        public BillableAssetData()
        {

        }

        public BillableAssetData(string name, MailAddress email, Guid id, Dictionary<ProjectData, List<TaskData>> work)  
        {
            this.resourceName = name;
            this.resourceEmail = email;
            this.resourceID = id;
            this.resourceWork = work;
        }
    }
}
