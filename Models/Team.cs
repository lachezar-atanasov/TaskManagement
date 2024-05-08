using System.Collections.Generic;
using System.Data;
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
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length,NameMinLength,NameMaxLength,_invalidNameErrorMessage);
                _name = value;
            }
        }

        public void AddMemberIfNotExists(IMember member)
        {
            if (_members.Contains(member))
            {
                string errorMessage = $"Team {this.Name} already has member with name {member.Name}";
                ActivityHistory.AddEventLog(errorMessage);
                throw new DuplicateNameException(errorMessage);
            }
            ActivityHistory.AddEventLog($"Member '{member.Name}' added to team! ");
            _members.Add(member);
        }
        public void AddBoardIfNotExists(IBoard board)
        {
            if (_boards.Contains(board))
            {
                string errorMessage = $"Team {this.Name} already has board with name {board.Name}";
                ActivityHistory.AddEventLog(errorMessage);
                throw new DuplicateNameException(errorMessage);
            }
            ActivityHistory.AddEventLog($"Board '{board.Name}' added to team! ");
            _boards.Add(board);
        }
        public List<IMember> Members => new(_members);
        public List<IBoard> Boards => new(_boards);
        public ActivityHistory ActivityHistory { get; } = new();
    
    }
}