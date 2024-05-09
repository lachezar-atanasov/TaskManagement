using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts.Generic
{
    public interface IPriorityAssignable
    {
        Priority Priority { get; }
        void SetPriority(Priority priority);
    }
}