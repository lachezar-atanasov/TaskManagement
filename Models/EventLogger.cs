using System;
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
        public IMember? Assigner { get; set; }
        public IBoard? CurrentBoard { get; set; }
        public ITeam? CurrentTeam { get; set; }
        public override string ToString()
        {
            return $"[{this.Time:HH:mm}] {this.Description} ({Time:dd.MM.yyyy})";
        }
    }
}

