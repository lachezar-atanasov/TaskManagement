using TaskManagement.Commands.Contracts;
using TaskManagement.Core.Contracts;
using System;
using TaskManagement.Exceptions;

namespace TaskManagement.Core
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

                    // | in the start of each line
                    string[] lines = result.Split(Environment.NewLine);
                    string formattedResult = string.Join(Environment.NewLine, Array.ConvertAll(lines, line => $"| {line.Trim()}"));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(formattedResult.Trim());
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        string message = ex.Message;
                        // | in the start of each line
                        string[] lines = message.Split(Environment.NewLine);
                        string formattedResult = string.Join(Environment.NewLine, Array.ConvertAll(lines, line => $"| {line.Trim()}"));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(formattedResult);
                        Console.ResetColor();
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