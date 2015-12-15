using System;


namespace DataAccess
{
    public class ResourceAccess : DataAccessLayer<BillableAssetData>
    {
        public ResourceAccess(string fileName) : base(fileName)
        {

        }

    }
}
