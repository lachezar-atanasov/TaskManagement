﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> _members = new List<IMember>();
        private readonly IList<ITeam> _teams = new List<ITeam>();
        IList<IMember> IRepository.Members => new List<IMember>(_members);
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

        public IComment CreateComment(string author, string message)
        {
            IComment comment = new Comment(author,message);
            return comment;
        }

        public void AddMemberIfNotExists(IMember member)
        {
            if (MemberExists(member.Name))
            {
                throw new DuplicateNameException("Member with that name already exists! ");
            }
            _members.Add(member);
        }

        public IMember GetMemberIfExists(string name)
        {
            CheckMemberExists(name);
            return _members.First(x => x.Name == name);
        }

        public void AddTeamIfNotExists(ITeam team)
        {
            if (TeamExists(team.Name))
            {
                throw new DuplicateNameException("Team with that name already exists! ");
            }
            _teams.Add(team);
        }
        public IBug CreateBug(string name, string description, Severity severity, Priority priority)
        {
            return new Bug(name,description, severity, priority);
        }
        public IStory CreateStory(string name, string description, Priority priority, Size size)
        {
            return new Story(name, description, priority, size);
        }
        public IFeedback CreateFeedback(string name, string description)
        {
            return new Feedback(name, description);
        }
        public void CheckMemberExists(string memberName)
        {
            if (!this.MemberExists(memberName))
            {
                throw new InvalidUserInputException("Member with that name doesn't exists! ");
            }
        }
        public void CheckTeamExists(string teamName)
        {
            if (!this.TeamExists(teamName))
            {
                throw new InvalidUserInputException("Team with that name doesn't exists! ");
            }
        }
        public void CheckBoardExists(string boardName, string teamName)
        {
            if (!this.BoardExists(boardName,teamName))
            {
                throw new InvalidUserInputException($"Board with that name doesn't exists in team '{teamName}'! ");
            }
        }
        public bool MemberExists(string name)
        {
            bool result = false;
            foreach (var member in _members)
            {
                if (member.Name.Equals(name))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public bool TeamExists(string name)
        {
            return _teams.Any(x => x.Name.Equals(name));
        }
        public bool BoardExists(string name, string teamName)
        {
            CheckTeamExists(teamName);
            return _teams.First(x=>x.Name==teamName).Boards.Any(x => x.Name.Equals(name));
        }

        public ITeam GetTeamIfExists(string name)
        {
            CheckTeamExists(name);
            return _teams.First(x => x.Name == name);
        }

        public IBoard GetBoardIfExists(string name,string teamName)
        {
            CheckBoardExists(name,teamName);
            var foundTeam = GetTeamIfExists(teamName);
            return foundTeam.Boards.First(x => x.Name == name);
        }

        public ITask GetTaskById(int id)
        {
            List<ITask> totalTasksCollection = new();
            totalTasksCollection = totalTasksCollection.Concat(_teams.SelectMany(x => x.Boards.SelectMany(y=>y.Tasks))).ToList();
            totalTasksCollection = totalTasksCollection.Concat((_members).SelectMany(x => x.Tasks)).ToList();
            var foundTask = totalTasksCollection.FirstOrDefault(x => x.Id == id);
            if (foundTask == null)
            {
                throw new InvalidUserInputException($"Task with that id doesn't exists! ");
            }
            return foundTask;
        }
    }
}