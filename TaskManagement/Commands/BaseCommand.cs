using OOP_Project_Telerik.Commands.Contracts;
using OOP_Project_Telerik.Core.Contracts;
using OOP_Project_Telerik.Exceptions;
using System.Collections.Generic;

namespace OOP_Project_Telerik.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            CommandParameters = commandParameters;
            Repository = repository;
        }

        public string Execute()
        {
            return ExecuteCommand();
        }

        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected void CheckParametersCount(int expectedParameters)
        {
            if (CommandParameters.Count != expectedParameters)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {expectedParameters}, Received: {CommandParameters.Count}");
            }
        }

        protected abstract string ExecuteCommand();
    }
}
