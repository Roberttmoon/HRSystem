using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Task : Project
    {
        protected string taskName;
        protected Guid taskID;

        public Task()
        {

        }

        public void AddHours(int hours)
        {
            throw new NotImplementedException();
        }

        public void AddResource(BillableAsset asset)
        {
            throw new NotImplementedException();
        }
    }
}
