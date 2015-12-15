using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FileAccessLayer
    {
        public string path;
        public string fileName;

        public FileAccessLayer(string fileName)
        {
            fileName = String.Format("@{0}.json", fileName);
            path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public void WriteAllText(string input)
        {
            File.WriteAllText(path, input);
        }

        public void AppendAllText(string path, string content)
        {
            File.AppendAllText(path, content);
        }

        public string GetAllText()
        {
            return File.ReadAllText(path);
        }
    }
}
