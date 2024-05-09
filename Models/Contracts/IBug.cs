using System.Collections.Generic;
using System.Net;
using TaskManagement.Models.Contracts.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IBug : ITask, IPriorityAssignable, ISeverityAssignable
    {
        List<string> Steps { get; }
        void AddSteps(List<string> stepsToAdd);
    }
}
