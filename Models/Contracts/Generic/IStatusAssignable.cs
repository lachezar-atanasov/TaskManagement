using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts.Generic
{
    public interface IStatusAssignable
    {
        Status Status { get; }
        void SetStatus(Status status);
    }
}