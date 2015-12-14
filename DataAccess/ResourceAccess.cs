using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTimeEntry;

namespace DataAccess
{
    public class ResourceAccess : DataAccessLayer<BillableAssetData>
    {
        public ResourceAccess(string fileName) : base(fileName)
        {

        }

        public ResourceReport GetResourceReport(BillableAssetData resource)
        {
            throw new NotImplementedException();
        }



    }
}
