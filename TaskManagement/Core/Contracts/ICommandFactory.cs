using OOP_Project_Telerik.Commands.Contracts;
using System;

namespace OOP_Project_Telerik.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}

