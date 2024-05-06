using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public abstract class Task : ITask
    {
        private const int NameMinLength = 10;
        private const int NameMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;
        private readonly string _nameErrorMessage = $"Name must be between {NameMinLength} and {NameMaxLength} characters";
        private readonly string _descriptionErrorMessage = $"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} characters";

        private readonly string _name;
        private readonly string _description;
        private readonly List<IComment> _comments = new();
        private static int _globalId = 0;

        protected Task(string name, string description, Status status)
        {
            Id = _globalId;
            Status = status;
            Name = name;
            Description = description;
            ActivityHistory.AddEventLog($"{GetType().Name} created! {Name} : {Description} {Environment.NewLine} {Status}");
            _globalId++;
        }
        public string Name
        {
            get => _name;
            private init
            {
                Validators.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, _nameErrorMessage);
                _name = value;
            }
        }
        public string Description
        {
            get => _description;
            private init
            {
                Validators.ValidateIntRange(value.Length, DescriptionMinLength, DescriptionMaxLength, _descriptionErrorMessage);
                _description = value;
            }
        }
        public int Id { get; }
        public Status Status { get; protected set; }
        public abstract void SetStatus(Status status);

        public List<IComment> Comments
        {
            get
            {
                var copy = new List<IComment>(_comments);
                return copy;
            }
        }
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public void AddLogWithAssignerIfPresent(string message)
        {
            if (Assignee == null)
            {
                ActivityHistory.AddEventLog(message);
            }
            else
            {
                ActivityHistory.AddEventLog(message, Assignee);
            }
        }
        public void AssignTo(IMember member)
        {
            ActivityHistory.AddEventLog($"{GetType().Name} assigned to member '{member.Name}'");
            Assignee = member;
        }
        public void Unassign()
        {
            if (Assignee == null)
            {
                string errorMessage = $"Task with id {Id} has no assignee yet! ";
                ActivityHistory.AddEventLog(errorMessage);
                throw new InvalidUserInputException(errorMessage);
            }
            ActivityHistory.AddEventLog($"{GetType().Name} unassigned from member '{Assignee.Name}'");
            Assignee = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string? assignee = Assignee?.Name;
            if (assignee != null)
            {
                assignee = ", Assignee: " + assignee;
            }
            sb.AppendLine($"ID: {Id}, Title of ({GetType().Name}): {Name}, Status: {Status}{AdditionalInfo()}{assignee}");
            return sb.ToString();
        }
        public abstract string AdditionalInfo();
        public ActivityHistory ActivityHistory { get; } = new();
        public IMember? Assignee { get; private set; }
    }
}