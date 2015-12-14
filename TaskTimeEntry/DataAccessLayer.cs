using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class DataAccessLayer
    {
        public string path;
        public string fileName;
        public JsonSerializer serializer;

        public int getProjectHoursActual(Guid projectID)
        {
            throw new NotImplementedException();
        }

        //ResourceReport getResourceReport(BillableAsset asset){}
        public void updateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
