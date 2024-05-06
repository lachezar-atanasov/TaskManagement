using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IStory: ITask, IPriorityAssignable
    {
        Size Size { get; }
        void SetSize(Size size);
    }
}
