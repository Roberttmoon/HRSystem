using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Task
    {
        public string taskName { get; set; }
        public Guid _id;
        public Guid projectID;
        public Dictionary<string, float> hoursLogged; 
        public Guid clientID;
        public float timeRemaining;
        public string status;
        public List<string> comments;

        public Task(Guid clientID, Guid projectID)
        {
            _id = Guid.NewGuid();
            this.clientID = clientID;
            this.projectID = projectID;
            comments = new List<string>();
            status = "Open";
            hoursLogged = new Dictionary<string, float>();
        }

        public void SetTimeRemaining(float timeWorked)
        {
            timeRemaining -= timeWorked;
            if (timeRemaining <= 0) status = "Closed";
        }

        public void AddTimeLog(string userName, float timeLogged)
        {
            string final = String.Format("{0}: {1}", userName, DateTime.Now.ToString());
            hoursLogged.Add(final, timeLogged);
        }

        public float AddHours(float hoursLogged)
        {
            float LogTime = timeRemaining;
            LogTime = (LogTime - hoursLogged);
            return LogTime;
        }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }



    }
}
