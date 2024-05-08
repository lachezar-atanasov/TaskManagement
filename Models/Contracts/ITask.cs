using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface ITask: INameable, IAssignee, IHistoryable, IStatusAssignable
    {
        string Description { get; }
        public int Id {  get; }
        List<IComment> Comments { get; } 
        void AddComment(IComment comment);
        void AssignTo(IMember member);
        void Unassign();

    }
}
