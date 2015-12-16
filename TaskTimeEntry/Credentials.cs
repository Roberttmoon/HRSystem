using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Credentials
    {
        private MailAddress email;
        private Guid id;
        private string password;

        public Credentials()
        {

        }

        public Credentials(MailAddress email, Guid id, string password)
        {
            this.email = email;
            this.id = id;
            this.password = password;
        }
    }
}
