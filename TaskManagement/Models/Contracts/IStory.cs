using OOP_Project_Telerik.Models.Enums;

namespace OOP_Project_Telerik.Models.Contracts
{
    public interface IStory: ITask, IPriority
    {
        Size Size { get; }
        void SetSize(Size size);
    }
}
