using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DBCredentials
    {
        private static string _mongoDBConnectionString = "mongodb://gandalf:fooledeverybody@ds047722.mongolab.com:47722/main";

        public static string mongoDBConnectionString { get { return _mongoDBConnectionString; } }
    }
}
