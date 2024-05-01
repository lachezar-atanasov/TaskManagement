using System;

namespace TaskManagement.Models.Contracts
{
    public interface IEventLogger
    {
        string Description { get; }
        DateTime Time { get; }
        string ViewInfo();
        IMember? Member { get; set; }
        IBoard Board { get; set; }
    }
}
