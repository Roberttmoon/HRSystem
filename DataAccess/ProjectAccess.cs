using System;

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
