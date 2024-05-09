using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts.Generic
{
    public interface ISeverityAssignable
    {
        Severity Severity { get; }
        void SetSeverity(Severity severity);
    }
}