using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    interface ITaskInteract
    {
        int logHours(Task task, int hours, string comment);
        // returns int hoursRemaining
        void closeTask(Task task);
        void addComment(Task task);
    }
}
