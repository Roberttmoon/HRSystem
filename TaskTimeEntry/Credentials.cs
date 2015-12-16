using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    [Serializable]
    public class Credentials
    {
        public string type { get; private set; }
        public string email { get; private set; }
        public Guid _id { get; private set; }
        public string password { get; private set; }

        public Credentials()
        {

        }

        public Credentials(string type, string email, Guid id, string password)
        {
            this.type = type;
            this.email = email;
            _id = id;
            this.password = password;
        }
    }
}
