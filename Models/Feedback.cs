using TaskManagement.Models.Enums;
using System;
using TaskManagement.Models.Contracts;
using TaskManagement.Exceptions;

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

        public override void SetStatus(Status status)
        {
            if (status != Status.New && status != Status.Unscheduled && status != Status.Scheduled && status != Status.Done)
            {
                throw new InvalidUserInputException($"Status {status} is not valid for Feedback!");
            }
            if (Status == Status.New && status == Status.New)
            {
                string errorMessage = $"Status already at New";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            if (Status == Status.Unscheduled && status == Status.Unscheduled)
            {
                string errorMessage = $"Status already at Unscheduled";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            if (Status == Status.Scheduled && status == Status.Scheduled)
            {
                string errorMessage = $"Status already at Scheduled";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            if (Status == Status.Done && status == Status.Done)
            {
                string errorMessage = $"Status already at Done";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }

            ActivityHistory.AddEventLog($"Status is set to {status}");
            Status = status;
        }
    }
}