using System;
using System.Collections.Generic;
using OOP_Project_Telerik.Helpers;
using OOP_Project_Telerik.Models.Contracts;

namespace OOP_Project_Telerik.Models
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
            _members.Add(member);
        }
        public void AddBoard(IBoard board)
        {
            _boards.Add(board);
        }
        public List<IMember> Members => new(_members);

        public List<IBoard> Boards => new(_boards);
    }
}