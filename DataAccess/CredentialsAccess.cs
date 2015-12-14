using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CredentialsAccess : DataAccessLayer<CredentialData>
    {
        public CredentialsAccess(string fileName) : base(fileName)
        {

        }

        public void EnterAccountCredentials(string email, Guid id, string password)
        {

        }

        public bool CheckCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
