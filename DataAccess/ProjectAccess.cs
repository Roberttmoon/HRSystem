using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTimeEntry;

namespace DataAccess
{
    public class ProjectAccess : DataAccessLayer<Client>
    {
        public ProjectAccess(string fileName) : base(fileName)
        {

        }
    }
}
