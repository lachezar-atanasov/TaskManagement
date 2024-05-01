using System;
using System.Collections.Generic;
using OOP_Project_Telerik.Models.Contracts;


namespace OOP_Project_Telerik.Models
{
    public static class ActivityHistory
    {
        public static List<IEventLogger> LogEvents = new();
        public static void AddEvent(IEventLogger log)
        {
            LogEvents.Add(log);
        }

        public static void AddEvent(string eventDescription)
        {
            EventLogger log = new EventLogger(eventDescription);
            AddEvent(log);
        }
        public static void AddEvent(string eventDescription,IMember member)
        {
            EventLogger log = new EventLogger(eventDescription)
            {
                Member = member
            };
            AddEvent(log);
        }
        public static void AddEvent(string eventDescription, IBoard board)
        {
            EventLogger log = new EventLogger(eventDescription)
            {
                Board = board
            };
            AddEvent(log);
        }

    }
}

