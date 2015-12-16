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
        public new Guid _id;
        public Guid projectID;
        public int hoursLogged
        {
            get; set;
        }

        public Task(Guid clientID, Guid projectID)
        {
            _id = Guid.NewGuid();
            this.clientID = clientID;
            this.projectID = projectID;
        }

        public int AddHours(int hoursLogged)
        {
            int manHours = 160;
            manHours = (manHours - hoursLogged);
            return manHours;
        }
    }
}
