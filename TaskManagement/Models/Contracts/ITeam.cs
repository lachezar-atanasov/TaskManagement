using System.Collections.Generic;

namespace OOP_Project_Telerik.Models.Contracts
{
    public interface ITeam : INameable
    {
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
    }
}
