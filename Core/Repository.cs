using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using TaskManagement.Core.Contracts;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> _members = new List<IMember>();
        private readonly IList<ITeam> _teams = new List<ITeam>();
        private readonly IList<IBoard> _boards = new List<IBoard>();
        IList<IMember> IRepository.Members => new List<IMember>(_members);
        IList<IBoard> IRepository.Boards => new List<IBoard>(_boards);
        IList<ITeam> IRepository.Teams => new List<ITeam>(_teams);

        IMember IRepository.CreateMember(string name)
        {
            return new Member(name);
        }

        IBoard IRepository.CreateBoard(string name)
        {
            return new Board(name);
        }

        ITeam IRepository.CreateTeam(string name)
        {
            return new Team(name);
        }

        public void AddMember(IMember member)
        {
            if (MemberExists(member.Name))
            {
                throw new DuplicatedEntityException("Member with that name already exists! ");
            }
            _members.Add(member);
        }

        public void AddTeam(ITeam team)
        {
            if (MemberExists(team.Name))
            {
                throw new DuplicatedEntityException("Team with that name already exists! ");
            }
            _teams.Add(team);
        }

        public void AddBoard(IBoard board)
        {
            if (MemberExists(board.Name))
            {
                throw new DuplicatedEntityException("Board with that name already exists! ");
            }
            _boards.Add(board);
        }

        public IBug CreateBug(string name, string description, Severity severity, Priority priority, IBoard board)
        {
            return new Bug(name,description, severity, priority, board);
        }

        public IStory CreateStory(string name, string description, Priority priority, Size size, IBoard board)
        {
            return new Story(name, description, priority, size, board);
        }
        public IFeedback CreateFeedback(string name, string description, IBoard board)
        {
            return new Feedback(name, description, board);
        }
        public bool MemberExists(string name)
        {
            bool result = false;
            foreach (var member in _members)
            {
                if (member.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool TeamExists(string name)
        {
            bool result = false;
            foreach (var team in _teams)
            {
                if (team.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool BoardExists(string name)
        {
            bool result = false;
            foreach (var board in _boards)
            {
                if (board.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}