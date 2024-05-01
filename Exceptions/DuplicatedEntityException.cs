using System;

namespace TaskManagement
{
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException(string message)
            : base(message)
        {
        }
    }
}
