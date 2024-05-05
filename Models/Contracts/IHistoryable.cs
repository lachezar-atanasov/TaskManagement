using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IHistoryable
    {
        ActivityHistory ActivityHistory { get; }
    }
}
