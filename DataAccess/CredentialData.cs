using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CredentialData
    {
        public string name { get; set; }
        public MailAddress email { get; set; }
        public Guid id { get; set; }

        public CredentialData()
        {

        }

        public CredentialData(string name, MailAddress email, Guid id)
        {
            this.name = name;
            this.email = email;
            this.id = id;
        }
    }
}
