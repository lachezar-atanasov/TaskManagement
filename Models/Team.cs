using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Team:ITeam
    {
        private string _name;
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private readonly string _invalidNameErrorMessage = $"The name must be a string between {NameMinLength} and {NameMaxLength} symbols.";
        private readonly List<IMember> _members=new();
        private readonly List<IBoard> _boards=new();

        public Team(string name)
        {
            Name = name;
            ActivityHistory.AddEventLog($"Team was created! ");
        }

        public string Name
        {
            //TODO: Unique name in application check
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length,NameMinLength,NameMaxLength,_invalidNameErrorMessage);
                _name = value;
            }
        }

        public void AddMember(IMember member)
        {
            if (_members.Contains(member))
            {
                throw new DuplicateNameException($"Team {this.Name} already has member with name {member.Name}");
            }
            _members.Add(member);
        }
        public void AddBoard(IBoard board)
        {
            if (_boards.Contains(board))
            {
                throw new DuplicateNameException($"Team {this.Name} already has board with name {board.Name}");
            }
            _boards.Add(board);
        }
        public List<IMember> Members => new(_members);
        public List<IBoard> Boards => new(_boards);
        public ActivityHistory ActivityHistory { get; } = new();
    
    }
}