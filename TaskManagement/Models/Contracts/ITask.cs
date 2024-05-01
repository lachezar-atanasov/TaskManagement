using System.Collections.Generic;
using OOP_Project_Telerik.Models.Enums;

namespace OOP_Project_Telerik.Models.Contracts
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
