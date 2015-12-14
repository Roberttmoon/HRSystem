using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    interface ITaskInteract
    {
        int LogTime(Task task, float time, string comment);
        // returns int hoursRemaining
        void CloseTask(Task task);
        void AddComment(Task task, string comment);
    }
}
