using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public DataAccessLayer(string fileName)
        {
            fileName = String.Format("@{0}.json", fileName);
            path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public bool CheckLogin(string email, string passwordEntered)
        {
            throw new NotImplementedException();
        }

        public int GetProjectHoursActual(Guid projectID)
        {
            throw new NotImplementedException();
        }

        public ResourceReport GetResourceReport(BillableAsset resource)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
