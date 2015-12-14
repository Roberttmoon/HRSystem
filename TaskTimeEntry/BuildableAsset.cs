using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem
{
    class BillAsset
    {
        string assetName;

        Guid employee;

        Dictionary<Project, int> employeeProjects;

        List<Task> employeeTask;

        float HourlyRate;

        float timeInvested;


    }
}
