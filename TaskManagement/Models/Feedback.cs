using OOP_Project_Telerik.Models.Enums;
using System;
using OOP_Project_Telerik.Models.Contracts;

namespace OOP_Project_Telerik.Models
{
    public class Feedback:Task,IFeedback
    {
        private int _rating;

        public Feedback(string name, string description, IBoard board) 
            : base(name, description, Status.New, board)
        {
        }

        public int Rating => _rating;

        public override void AdvanceStatus()
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
            base.AdvanceStatus();
        }

        public override void RevertStatus()
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
            base.RevertStatus();
        }
    }
}