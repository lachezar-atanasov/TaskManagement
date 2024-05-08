using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IBug : ITask, IPriorityAssignable,ISeverityAssignable
    {
        List<string> Steps { get; }
    }
}
