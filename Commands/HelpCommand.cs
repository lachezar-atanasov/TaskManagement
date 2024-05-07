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
            bool firstEnumValueSkipped = false;
            foreach (CommandType commandType in Enum.GetValues(typeof(CommandType)))
            {
                if (!firstEnumValueSkipped)
                {
                    firstEnumValueSkipped = true;
                    continue; 
                }
                sb.AppendLine($"{(int)commandType}: {commandType}");
            }
            sb.Append("-------------------");
            return sb.ToString();
        }
    }
}