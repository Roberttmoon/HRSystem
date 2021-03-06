﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillableAssetData
    {
        public string resourceName { get; set; }
        public MailAddress resourceEmail { get; set; }
        public Guid resourceID { get; set; }
        public List<Dictionary<ProjectData, List<TaskData>>> resourceWork { get; set; }
        public override string ToString()
        {
            return String.Format("{0} ProjectData");
        }

        public BillableAssetData()
        {

        }

        public BillableAssetData(string name, MailAddress email, Guid id, List<Dictionary<ProjectData, List<TaskData>>> work)  
        {
            this.resourceName = name;
            this.resourceEmail = email;
            this.resourceID = id;
            this.resourceWork = work;
        }
    }
}
