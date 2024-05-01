using System.Collections.Generic;
using OOP_Project_Telerik.Helpers;
using OOP_Project_Telerik.Models.Contracts;

namespace OOP_Project_Telerik.Models
{
    public class Board:IBoard
    {
        private string _name;
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;
        private readonly string _invalidNameErrorMessage = $"The name must be a string between {NameMinLength} and {NameMaxLength} symbols.";

        public Board(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            private set
            {
                Validators.ValidateIntRange(value.Length,NameMinLength,NameMaxLength,_invalidNameErrorMessage);
                _name = value; 
            }
        }
    }
}
