using System.Collections.Generic;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Board:IBoard
    {
        private string _name;
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;
        private readonly string _invalidNameErrorMessage = $"The name must be a string between {NameMinLength} and {NameMaxLength} symbols.";

        private readonly List<ITask> _tasks = new List<ITask>();
        public Board(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length,NameMinLength,NameMaxLength,_invalidNameErrorMessage);
                _name = value; 
            }
        }

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }
        public List<ITask> Tasks => new(_tasks);
        public ActivityHistory ActivityHistory { get; }
    }
}
