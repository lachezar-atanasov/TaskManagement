using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Commands
{
    public class ChangeBugSeverity : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeBugSeverity(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugSeverity(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Severity newBugSeverity = ParseHelper.ParseSeverityParameter(CommandParameters[1]);

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Bug with id {bugId} is not bug! ");
            }

            bug.SetSeverity(newBugSeverity);
            return $"Bug with name {bug.Name} successfully changed severity to {newBugSeverity}'!";
        }
    }
}