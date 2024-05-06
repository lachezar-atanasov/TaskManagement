using System;
using TaskManagement.Exceptions;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Story : Task, IStory
    {
        public Story(string name, string description, Priority priority, Size size) 
            :base(name, description, Status.NotDone)
        {
            Priority = priority;
            Size = size;
        }
        public Priority Priority { get; private set; }

        public void SetPriority(Priority priority)
        {
            if(Priority != priority)
            {
                Priority saveValue = Priority;
                Priority = priority;
                string logMessage = $"Priority set from {saveValue} to {Priority}";
                AddLogWithAssignerIfPresent(logMessage);
            }
            else
            {
                string errorMessage = $"Priority already at {Priority}";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
            
        }

        public Size Size { get; private set; }

        public void SetSize(Size size)
        {
            if(Size != size)
            {
                Size saveValue = Size;
                Size = size;
                AddLogWithAssignerIfPresent($"Size set from {saveValue} to {Size}");
            }
            else
            {
                string errorMessage = $"Size already at {Size}";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
            
        }

        public override void SetStatus(Status status)
        {
            if (status != Status.NotDone && status != Status.InProgress && status != Status.Done)
            {
                throw new InvalidUserInputException($"Status {status} is not valid for Story!");
            }
            if (Status == Status.NotDone && status == Status.NotDone)
            {
                string errorMessage = $"Status already at NotDone";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            if (Status == Status.InProgress && status == Status.InProgress)
            {
                string errorMessage = $"Status already at InProgress";
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