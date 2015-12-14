using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTimeEntry;

namespace DataAccess
{
    public class ProjectAccess : DataAccessLayer<ClientData>
    {
        public ProjectAccess(string fileName) : base(fileName)
        {

        }

        public int GetProjectHoursActual(Guid projectID)
        {
            throw new NotImplementedException();
        }
    }
}
