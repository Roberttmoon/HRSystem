using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class BillableAsset
    {
        private string name;
        private Guid employeeID;
        private Dictionary<Project, int> projects;
        private List<Task> tasks;
        float hourlyRate;

        public BillableAsset()
        {

        }

        public void AddTime(Project project, int time)
        {
            throw new NotImplementedException();
        }

    }
}
