using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TaskData : ProjectData
    {
        public string taskName;
        public Guid taskID;

        public TaskData()
        {

        }

        public TaskData(string taskName, Guid taskID)
        {
            this.taskName = taskName;
            this.taskID = taskID;
        }
    }
}
