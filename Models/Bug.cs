using System;
using System.Collections.Generic;
using TaskManagement.Exceptions;
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

        public override void SetStatus(Status status)
        {
            if (status!=Status.Active && status!=Status.Fixed)
            {
                throw new InvalidUserInputException($"Status {status} is not valid for Bug!");
            }
            if (Status == Status.Active && status == Status.Active)
            {
                string errorMessage = "Status already at Active";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            if (Status == Status.Fixed && status == Status.Fixed)
            {
                string errorMessage = "Status already at Fixed";
                AddLogWithAssignerIfPresent(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }

            ActivityHistory.AddEventLog($"Status is set to {status}");
            Status = status;
        }

        public override string AdditionalInfo()
        {
            return $", Severity: { Severity}, Priority: { Priority}";
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

        public void SetSeverity(Severity severity)
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
    }
}
