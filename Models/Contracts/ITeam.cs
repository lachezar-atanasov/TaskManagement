using System.Collections.Generic;
using TaskManagement.Models.Contracts.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface ITeam : INameable, IHistoryable
    {
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
        void AddMemberIfNotExists(IMember member);
        void AddBoardIfNotExists(IBoard board);
    }
}
