using System;
using System.Collections.Generic;
using System.Data;
using OOP_Project_Telerik.Models.Contracts;
using OOP_Project_Telerik.Models.Enums;

namespace OOP_Project_Telerik.Core.Contracts
{
    public interface IRepository
    {
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        IList<ITeam> Teams { get; }
        IMember CreateMember(string name);
        IBoard CreateBoard(string name);
        ITeam CreateTeam(string name);
        void AddMember(IMember member);
        bool MemberExists(string name);
        bool TeamExists(string name);
        bool BoardExists(string name);
        void AddTeam(ITeam team);
        void AddBoard(IBoard board);
        IBug CreateBug(string name, string description, Severity severity, Priority priority, IBoard board);
        IStory CreateStory(string name, string description, Priority priority, Size size, IBoard board);
        IFeedback CreateFeedback(string name, string description, IBoard board);

    }
}
