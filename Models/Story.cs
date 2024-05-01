using System;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Story : Task, IStory
    {
        public Story(string name, string description, Priority priority, Size size, IBoard board) 
            :base(name, description, Status.NotDone, board)
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
                AddLogWithAssigner(logMessage);
            }
            else
            {
                string errorMessage = $"Priority already at {Priority}";
                AddLogWithAssigner(errorMessage);
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
                ActivityHistory.AddEvent($"Size set from {saveValue} to {Size}");
            }
            else
            {
                throw new ArgumentException($"Size already at {Size}");
            }
            
        }

        public override void AdvanceStatus()
        {
            if(Status  == Status.Done)
            {
                throw new ArgumentException("Status already at Done");
            }
            else
            {
                base.AdvanceStatus();
                Status += 1;
            }
            //TODO: event history implementation
        }

        public override void RevertStatus()
        {
            if(Status == Status.NotDone)
            {
                throw new ArgumentException("Status already Not Done");
            }

            base.RevertStatus();
            Status -= 1;
        }
    }
}