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

        public void AddHours(int hours)
        {
            throw new NotImplementedException();
        }
    }
}
