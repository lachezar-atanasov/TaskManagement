using System.Collections.Generic;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface ITask: INameable, IAssignee, IHistoryable, IStatusAssignable
    {
        string Description { get; }
        public int Id {  get; }
        List<IComment> Comments { get; } 
        void AddComment(Comment comment);
        void AssignTo(IMember member);

    }
}
