using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public class BillableAsset
    {
        public string name { get; private set; }
        public MailAddress email { get; private set; }
        public Guid employeeID { get; private set; }
        public Dictionary<Project, List<Task>> assignedWork { get; private set; }
        public float hourlyRate { get; private set; }

        public BillableAsset()
        {

        }

        public void AddTime(Project project, int time)
        {
            throw new NotImplementedException();
        }
    }
}
