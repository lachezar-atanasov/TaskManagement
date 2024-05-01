using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IPriority
    {
        Priority Priority { get; }
        void SetPriority(Priority priority);
    }
}