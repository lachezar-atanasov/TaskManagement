using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ChangeBugSeverityCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeBugSeverityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugSeverityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters, $"{CommandType.ChangeBugSeverity} 'bugId' " +
                                                      $"'newSeverity({Severity.Minor}, {Severity.Major}, {Severity.Critical})'");
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Severity newBugSeverity = ParseHelper.ParseSeverityParameter(CommandParameters[1]);

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Task with id {bugId} is not bug! ");
            }

            bug.SetSeverity(newBugSeverity);
            return $"Bug with name '{bug.Name}' successfully changed severity to {newBugSeverity}'!";
        }
    }
}