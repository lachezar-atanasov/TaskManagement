using System;
using System.Collections.Generic;
using OOP_Project_Telerik.Models.Contracts;
using OOP_Project_Telerik.Models.Enums;


namespace OOP_Project_Telerik.Models
{
    public class Bug : Task, IBug
    {
        private readonly List<string> _steps = new();

        public Bug(string name, string description, Severity severity, Priority priority, IBoard board) 
            :base( name, description,Status.Active,board)
        {
            Priority = priority;
            Severity = severity;
        }
        public List<string> Steps=>new(_steps);
        public Severity Severity { get; private set; }
        public Priority Priority { get; private set; }

        public override void AdvanceStatus()
        {
            if(Status == Status.Active)
            {
                base.AdvanceStatus();
                Status = Status.Fixed;
            }
            else
            {
                throw new ArgumentException("Status already at Fixed");
            }
           
        }

        public void SetPriority(Priority priority)
        {
            if(Priority != priority) 
            {
                Priority saveValue = Priority;
                Priority = priority; 
                ActivityHistory.AddEvent($"Priority set from {saveValue} to {Priority}");
            }
            else
            {
                throw new ArgumentException($"Priority already at {Priority}");
            }
        }

        public void ChangeSeverity(Severity severity)
        {
            if(Severity != severity)
            {
                Severity saveValue = Severity;
                Severity = severity;
                ActivityHistory.AddEvent($"Severity set from {saveValue} to {Severity}");
            }
            else
            {
                throw new ArgumentException($"Severity already at {Severity}");
            }
        }

        public void AddStep(string stepToAdd)
        {
            _steps.Add(stepToAdd);
        }
        public override void RevertStatus()
        {
            if(Status == Status.Fixed)
            {
                base.RevertStatus();
                Status = Status.Active;
            }
            else
            {
                throw new ArgumentException("Status already at Active");
            }
        }
    }
}
