using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Commands
{
    public class HelpCommand : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public HelpCommand(IRepository repository)
            : base(repository)
        {
        }
        public HelpCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Available Commands:");

            // Get all enum values except the first one (Default)
            CommandType[] commandTypes = Enum.GetValues(typeof(CommandType))
                .Cast<CommandType>()
                .Skip(1) // Skip the Default value
                .ToArray();

            int totalCommands = commandTypes.Length;
            int commandsPerColumn = 11; // Fixed to 13 rows per column
            int columnWidth = 30; // Each command is padded to 30 characters

            for (int i = 0; i < commandsPerColumn; i++)
            {
                // For each row, append the command from each column
                for (int j = 0; j < 3; j++)
                {
                    int index = i + j * commandsPerColumn;
                    if (index < totalCommands)
                    {
                        // Format the command to be padded to 30 characters
                        string command = $"{(int)commandTypes[index]}: {commandTypes[index]}";
                        sb.Append(command.PadRight(columnWidth));
                    }
                    else
                    {
                        // If there's no command for this position, just append spaces
                        sb.Append(' ', columnWidth);
                    }
                }
                sb.AppendLine(); // Move to the next line after appending all three columns
            }

            sb.Append("-------------------");
            return sb.ToString();
        }
    }
}