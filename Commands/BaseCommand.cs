using System;
using TaskManagement.Commands.Contracts;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;

namespace TaskManagement.Commands
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

        protected void CheckParametersCount(int expectedParameters, string? syntaxHelper = null)
        {
            if (CommandParameters.Count != expectedParameters)
            {
                if (syntaxHelper != null)
                {
                    syntaxHelper = Environment.NewLine + "Right command syntax: " + syntaxHelper;
                }
                else
                {
                    syntaxHelper = "";
                }
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {expectedParameters}, Received: {CommandParameters.Count}{syntaxHelper}");
            }
        }
        protected void CheckParametersCount(int startRange,int endRange, string? syntaxHelper = null)
        {
            if (CommandParameters.Count < startRange || CommandParameters.Count > endRange)
            {
                if (syntaxHelper != null)
                {
                    syntaxHelper = Environment.NewLine + "Right command syntax: " + syntaxHelper;
                }
                else
                {
                    syntaxHelper = "";
                }
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {startRange} to {endRange}, Received: {CommandParameters.Count}{syntaxHelper}");
            }
        }

        protected abstract string ExecuteCommand();
    }
}
