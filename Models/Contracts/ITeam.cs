using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface ITeam : INameable, IHistoryable
    {
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
        void AddMember(IMember member);
        void AddBoard(IBoard board);
    }
}
