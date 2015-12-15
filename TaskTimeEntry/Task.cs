using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Task : Project
    {
        public string taskName { get; set; }
        public Guid taskID;

        public Task()
        {

        }

        public int AddHours(int hours)
        {
            int manHours = 160;
            manHours = (manHours - hours);
            return manHours;
        }
    }
}
