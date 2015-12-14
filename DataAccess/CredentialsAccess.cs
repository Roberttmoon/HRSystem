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

        public void EnterAccountCredentials(string email, Guid id, string password)
        {

        }
        public static void ValidateEmail(string email, ref MailAddress email)
        {

        }


    }
}
