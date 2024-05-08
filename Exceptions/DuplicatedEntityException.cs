using System;

namespace TaskManagement.Exceptions
{
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException(string message)
            : base(message)
        {
        }
    }
}
