using OOP_Project_Telerik.Models.Enums;

namespace OOP_Project_Telerik.Models.Contracts
{
    public interface IPriority
    {
        Priority Priority { get; }
        void SetPriority(Priority priority);
    }
}