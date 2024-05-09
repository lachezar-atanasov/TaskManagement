using System.Collections.Generic;
using TaskManagement.Models.Contracts.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IBoard : INameable, IHistoryable
    {
        List<ITask> Tasks { get; }
        void AddTask(ITask task);
    }
}

