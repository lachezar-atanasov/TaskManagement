using System.Collections.Generic;
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
        IComment CreateComment(string author,string message);
        void AddMemberIfNotExists(IMember member);
        void CheckMemberExists(string memberName);
        void CheckBoardExists(string boardName, string teamName);
        void CheckTeamExists(string teamName);
        bool MemberExists(string name);
        bool TeamExists(string name);
        bool BoardExists(string name, string teamName);
        ITeam GetTeamIfExists(string name);
        IBoard GetBoardIfExists(string name, string teamName);
        IMember GetMemberIfExists(string name);
        void AddTeamIfNotExists(ITeam team);
        ITask GetTaskById(int id);
        IBug CreateBug(string name, string description, Severity severity, Priority priority);
        IStory CreateStory(string name, string description, Priority priority, Size size);
        IFeedback CreateFeedback(string name, string description);

    }
}
