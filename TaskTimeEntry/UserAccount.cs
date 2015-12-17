using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public abstract class UserAccount
    {
        public string name { get; set; }
        public string email { get; protected set; }
        public Guid _id { get; protected set; }
        public bool privilege { get; set; }
        public List<Guid> projects { get; protected set; }

        public void AddProject(Guid id)
        {
            projects.Add(id);
        }

        public int LogTime(Task task, float time, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
