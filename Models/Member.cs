using TaskManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Member : IMember
    {
        private string _name;
        
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private readonly string _invalidNameErrorMessage = $"The name must be a string between {NameMinLength} and {NameMaxLength} symbols.";
        private readonly List<EventLogger> _logEvents = new();
        public Member(string name)
        {
            Name = name;
            ActivityHistory.AddEvent($"Member with name {this.Name} created!",this);
        }

        public string Name
        {
            //TODO: Unique name in application check
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, _invalidNameErrorMessage);
                _name = value;
            }
        }

        public List<EventLogger> LogEvents => new(_logEvents);
        public void AddEventLog(string message)
        {
            _logEvents.Add(new EventLogger(message));
        }
    }
}