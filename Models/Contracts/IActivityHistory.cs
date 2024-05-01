using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IActivityHistory
    {
        List<IEventLogger> LogEvents { get; }
        void AddEventLog(string message);
    }
}
