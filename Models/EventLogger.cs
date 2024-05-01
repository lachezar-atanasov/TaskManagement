using System;
using System.Collections.Generic;
using TaskManagement.Models.Contracts;


namespace TaskManagement.Models
{
    public class EventLogger : IEventLogger
    {
        public EventLogger(string description)
        {
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Time = DateTime.Now;
        }
        public string Description { get; }
        public DateTime Time { get; }
        public IMember? Member { get; set; }
        public override string ToString()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{this.Description}";
        }
    }
}

