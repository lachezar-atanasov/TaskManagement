using System.Collections.Generic;
using OOP_Project_Telerik.Models.Enums;

namespace OOP_Project_Telerik.Models.Contracts
{
    public interface IBug : ITask, IPriority
    {
        List<string> Steps { get; }
        Severity Severity { get; }
        void ChangeSeverity(Severity severity);
    }
}
