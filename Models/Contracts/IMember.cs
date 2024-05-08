using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IMember : INameable, IHistoryable
    { 
        void AddTask(ITask task);
      List<ITask> Tasks { get; }
    }
}
