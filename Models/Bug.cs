using System;
using System.Collections.Generic;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;


namespace TaskManagement.Models
{
    public class Bug : Task, IBug
    {
        private readonly List<string> _steps = new();

        public Bug(string name, string description, Severity severity, Priority priority) 
            :base( name, description,Status.Active)
        {
            Priority = priority;
            Severity = severity;
        }
        public List<string> Steps=>new(_steps);
        public Severity Severity { get; private set; }
        public Priority Priority { get; private set; }

        public override void AdvanceStatusAndLog()
        {
            if(Status == Status.Active)
            {
                base.AdvanceStatusAndLog();
                Status = Status.Fixed;
            }
            else
            {
                string errorMessage = $"Status already at Fixed";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
           
        }

        public void SetPriority(Priority priority)
        {
            if(Priority != priority) 
            {
                Priority saveValue = Priority;
                Priority = priority; 
                AddLogWithAssignerIfPresent($"Priority set from {saveValue} to {Priority}");
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
                AddLogWithAssignerIfPresent($"Severity set from {saveValue} to {Severity}");
            }
            else
            {
                string errorMessage = $"Severity already at {Severity}";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new ArgumentException(errorMessage);
            }
        }

        public void AddStep(string stepToAdd)
        {
            _steps.Add(stepToAdd);
        }
        public override void RevertStatusAndLog()
        {
            if(Status == Status.Fixed)
            {
                base.RevertStatusAndLog();
                Status = Status.Active;
            }
            else
            {
                throw new ArgumentException("Status already at Active");
            }
        }
    }
}
