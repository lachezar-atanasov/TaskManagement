using System.Collections.Generic;
using TaskManagement.Models.Contracts;


namespace TaskManagement.Models
{
    public class ActivityHistory : IActivityHistory
    {
        private readonly List<IEventLogger> _logEvents = new();
        public List<IEventLogger> LogEvents => new (_logEvents);
        public void AddEventLog(string message)
        { 
            EventLogger log = new(message);
            _logEvents.Add(log);
        }
        public void AddEventLog(string message,IMember assigner)
        {
            EventLogger log = new(message)
            {
                Assigner = assigner
            };
            _logEvents.Add(log);
        }

    }
}

