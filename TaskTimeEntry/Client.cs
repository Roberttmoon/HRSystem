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
        private float discount;

        public Client()
        {

        }

        static public Client createAssit(string name, MailAddress email)
        {
            Client newClinet = new Client();
            newClinet.id = Guid.NewGuid();
            newClinet.name = name;
            newClinet.email = email;
            return newClinet;
        }
    }
}
