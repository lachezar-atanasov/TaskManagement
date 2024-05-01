using System;

namespace OOP_Project_Telerik.Exceptions
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
