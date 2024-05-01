using System;

namespace TaskManagement.Exceptions
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
