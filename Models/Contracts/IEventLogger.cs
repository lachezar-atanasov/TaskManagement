using System;

namespace TaskManagement.Models.Contracts
{
    public interface IEventLogger
    {
        string Description { get; }
        DateTime Time { get; }
        IMember? Member { get; set; }
    }
}
