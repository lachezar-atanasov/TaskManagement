using System;
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

        public override void AdvanceStatusAndLog()
        {
            if(Status  == Status.Done)
            {
                string errorMessage = "Status already at Done";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
            base.AdvanceStatusAndLog();
            Status += 1;
        }

        public override void RevertStatusAndLog()
        {
            if(Status == Status.NotDone)
            {
                string errorMessage = "Status already Not Done";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
            base.RevertStatusAndLog();
            Status -= 1;
        }
    }
}