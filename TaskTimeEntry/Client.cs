using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public class Client : UserAccount
    {
        public float discount { get; private set; }

        public Client()
        {

        }

        public Client(string name, string email, float discount)
        {
            this.name = name;
            this.email = new MailAddress(email);
            this.id = Guid.NewGuid();
            this.projects = new List<Project>();
            this.tasks = new List<Task>();
        }
    }
}
