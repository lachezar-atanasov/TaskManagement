using System;
using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IBoard : INameable, IHistoryable
    {
        ITeam Team { get; }
    }
}

