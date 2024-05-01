using System.Collections.Generic;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface ITask: INameable, IAssignee
    {
        string Description { get; }
        public int Id {  get; }
        Status Status { get; }
        List<IComment> Comments { get; } 
        void AddComment(Comment comment);
        void AdvanceStatus();
        void RevertStatus();

    }
}
