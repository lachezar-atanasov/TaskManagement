using System;

namespace TaskManagement.Models.Contracts
{
    public interface IEventLogger
    {
        string Description { get; }
        DateTime Time { get; }
        IMember? Member { get; set; }
        IBoard? Board { get; set; }
        IBoard? Team { get; set; }
    }
}
