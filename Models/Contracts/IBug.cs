using System.Collections.Generic;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IBug : ITask, IPriorityAssignable,ISeverityAssignable
    {
        List<string> Steps { get; }
    }
}
