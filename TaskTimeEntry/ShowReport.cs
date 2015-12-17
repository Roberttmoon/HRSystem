using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
   
    public class ShowReport
    {
        public List<Client> clients = ModelView.GetAllClients();
        public Task task;
        public Project project;
        public List<string> comments;

        public IEnumerable<string> DisplayReport()
        {
            //comments = new List<string>();
            IEnumerable<string> result = from message in Enumerable.ToList(comments)
                                      select message;

            foreach (string message in result)
            {
                yield return message;
            }

        }



    }
}
