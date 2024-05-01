using TaskManagement.Commands.Contracts;
using System;

namespace TaskManagement.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}

