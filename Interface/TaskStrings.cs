using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class TaskStrings
    {
        public string name { get; set; }
        public string id { get; set; }
        public string projId { get; set; }
        public string clientId { get; set; }

        public TaskStrings(TaskTimeEntry.Task task)
        {
            name = task.taskName;
            id = task._id.ToString();
            projId = task.projectID.ToString();
            clientId = task.clientID.ToString();
        }
    }
}
