using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientData
    {
        public string clientName { get; set; }
        public MailAddress clientEmail { get; set; }
        public Guid clientID { get; set; }
        public Dictionary<ProjectData, List<TaskData>> clientWork { get; set; }

        public ClientData()
        {

        }
    }
}
