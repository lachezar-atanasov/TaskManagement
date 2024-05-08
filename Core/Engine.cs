using TaskManagement.Commands.Contracts;
using TaskManagement.Core.Contracts;
using System;
using System.Linq;
using TaskManagement.Commands.Enums;
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
                        string[] lines = message.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        const string RightSyntax = $"Right command syntax:";

                        foreach (string line in lines)
                        {
                            if (line.Contains(RightSyntax))
                            {
                                int index = line.IndexOf(RightSyntax, StringComparison.Ordinal);
                                string leftPart = line.Substring(0, index+RightSyntax.Length);
                                string rightPart = line.Substring(index+RightSyntax.Length);

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(leftPart);

                                
                                foreach (string word in rightPart.Split(' '))
                                {
                                    if (Enum.GetNames(typeof(CommandType)).ToList().Contains(word))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write(word + " ");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(word + " ");
                                    }
                                }

                                Console.WriteLine();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"| {line.Trim()}");
                            }
                        }
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