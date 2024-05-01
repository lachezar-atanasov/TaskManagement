using System;

namespace OOP_Project_Telerik
{
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException(string message)
            : base(message)
        {
        }
    }
}
