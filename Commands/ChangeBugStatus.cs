using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Commands
{
    public class ChangeBugStatus : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeBugStatus(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugStatus(IList<string> commandParameters, IRepository repository)
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