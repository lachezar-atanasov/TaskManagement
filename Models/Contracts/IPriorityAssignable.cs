using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IPriorityAssignable
    {
        Priority Priority { get; }
        void SetPriority(Priority priority);
    }
}