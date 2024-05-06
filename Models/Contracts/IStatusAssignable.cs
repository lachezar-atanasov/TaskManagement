using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IStatusAssignable
    {
        Status Status { get; }
        void SetStatus(Status status);
    }
}