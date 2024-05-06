using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface ISeverityAssignable
    {
        Severity Severity { get; }
        void SetSeverity(Severity severity);
    }
}