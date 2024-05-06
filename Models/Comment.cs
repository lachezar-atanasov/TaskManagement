using System;
using TaskManagement.Models.Contracts;


namespace TaskManagement.Models
{
    public class Comment : IComment
    {
        public Comment(string author, string message)
        {
            Author = author;
            Message = message;
        }

        public string Author { get; }
        public string Message { get; }
    }
}
