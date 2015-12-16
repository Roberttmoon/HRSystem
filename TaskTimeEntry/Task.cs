﻿using System;
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
        public int hoursLogged{ get; set;}           
        public Guid clientID;
        public float timeRemaining;
        public List<string> comments;

        public Task(Guid clientID, Guid projectID)
        {
            _id = Guid.NewGuid();
            this.clientID = clientID;
            this.projectID = projectID;
            this.comments = new List<string>();
        }

        public int AddHours(int hoursLogged)
        {
            int LogTime = 160;
            LogTime = (LogTime - hoursLogged);
            return LogTime;
        }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }
    }
}
