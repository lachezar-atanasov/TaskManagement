using TaskManagement.Models.Enums;
using System;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Feedback:Task,IFeedback
    {
        private int _rating;

        public Feedback(string name, string description) 
            : base(name, description, Status.New)
        {
        }

        public int Rating => _rating;

        public override void AdvanceStatusAndLog()
        {
            if (Status==Status.New)
            {
                Status=Status.Unscheduled;
            }
            if (Status == Status.Unscheduled)
            {
                Status = Status.Scheduled;
            }
            if (Status == Status.Scheduled)
            {
                Status = Status.Done;
            }
            if (Status == Status.Done)
            {
                throw new ArgumentException("Already at Done");
            }
            base.AdvanceStatusAndLog();
        }

        public override void RevertStatusAndLog()
        {
            if (Status == Status.New)
            {
                throw new ArgumentException("Already at New");
            }
            if (Status == Status.Unscheduled)
            {
                Status = Status.New;
            }
            if (Status == Status.Scheduled)
            {
                Status = Status.Unscheduled;
            }
            if (Status == Status.Done)
            {
                Status = Status.Scheduled;
            }
            base.RevertStatusAndLog();
        }
    }
}