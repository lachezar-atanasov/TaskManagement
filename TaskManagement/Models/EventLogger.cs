using System;
using System.Collections.Generic;
using OOP_Project_Telerik.Models.Contracts;


namespace OOP_Project_Telerik.Models
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
        public IBoard Board { get; set; }
        public string ViewInfo()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{this.Description}";
        }
    }
}

