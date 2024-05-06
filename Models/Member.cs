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
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private readonly string _invalidNameErrorMessage = $"The name must be a string between {NameMinLength} and {NameMaxLength} symbols.";

        private string _name;
        private readonly List<ITask> _tasks = new();

        public Member(string name)
        {
            Name = name;
            ActivityHistory.AddEventLog($"Member with name {this.Name} created!");
        }

        public string Name
        {
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, _invalidNameErrorMessage);
                _name = value;
            }
        }

        public void AddTask(ITask task)
        {
            ActivityHistory.AddEventLog($"{task.GetType().Name} with name {task.Name} assigned!");
            task.AssignTo(this);
            _tasks.Add(task);
        }
        public ActivityHistory ActivityHistory { get; } = new();
        public List<ITask> Tasks => new(_tasks);
    }
}