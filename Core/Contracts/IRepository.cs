using System;
using System.Collections.Generic;
using System.Data;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Core.Contracts
{
    public interface IRepository
    {
        IList<IMember> Members { get; }
        IList<ITeam> Teams { get; }
        IMember CreateMember(string name);
        IBoard CreateBoard(string name);
        ITeam CreateTeam(string name);
        void AddMember(IMember member);
        void CheckMemberExists(string memberName);
        void CheckBoardExists(string boardName);
        void CheckTeamExists(string teamName);
        bool MemberExists(string name);
        bool TeamExists(string name);
        bool BoardExists(string name);
        void AddTeam(ITeam team);
        IBug CreateBug(string name, string description, Severity severity, Priority priority);
        IStory CreateStory(string name, string description, Priority priority, Size size);
        IFeedback CreateFeedback(string name, string description);

    }
}
