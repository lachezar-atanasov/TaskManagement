using System;

namespace TaskManagement.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}