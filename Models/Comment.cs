using System;
using TaskManagement.Models.Contracts;


namespace TaskManagement.Models
{
    public class Comment : IComment
    {
        public string Author => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();
    }
}
