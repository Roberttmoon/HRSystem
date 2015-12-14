using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CredentialsAccess : DataAccessLayer<Dictionary<MailAddress, string>>
    {
        public CredentialsAccess(string fileName) : base(fileName)
        {

        }
    }
}
