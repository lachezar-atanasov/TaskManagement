using System.Collections.Generic;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IBug : ITask, IPriority
    {
        List<string> Steps { get; }
        Severity Severity { get; }
        void ChangeSeverity(Severity severity);
    }
}
