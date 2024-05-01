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
        public Member(string name)
        {
            Name = name;
            ActivityHistory.AddEventLog($"Member with name {this.Name} created!");
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

        public ActivityHistory ActivityHistory { get; } = new();
    }
}