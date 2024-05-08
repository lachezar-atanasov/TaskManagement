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
    public class ChangeBugStatusCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeBugStatusCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters, $"{CommandType.ChangeBugStatus} 'bugId' " +
                                                     $"'newStatus({Status.Active},{Status.Fixed})'");
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Status newBugStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Task with id {bugId} is not bug! ");
            }

            bug.SetStatus(newBugStatus);
            return $"Bug with name {bug.Name} successfully changed priority to {newBugStatus}'!";
        }
    }
}