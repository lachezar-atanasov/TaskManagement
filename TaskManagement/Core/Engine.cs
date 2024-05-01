using OOP_Project_Telerik.Commands.Contracts;
using OOP_Project_Telerik.Core.Contracts;
using System;
using OOP_Project_Telerik.Exceptions;

namespace OOP_Project_Telerik.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";
        private const string EmptyCommandError = "Command cannot be empty.";

        private readonly ICommandFactory _commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        throw new InvalidUserInputException(EmptyCommandError);
                    }

                    if (inputLine.ToLower() == TerminationCommand)
                    {
                        break;
                    }

                    ICommand command = _commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}