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
    public class ChangeBugPriorityCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        private string _bugPriorities = $"{Priority.Low}, {Priority.Medium}, {Priority.High}";
        public ChangeBugPriorityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugPriorityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeBugPriority} 'bugId' 'newPriority({_bugPriorities})'");
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Priority newBugPriority = ParseHelper.ParsePriorityParameter(CommandParameters[1]);

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Task with id {bugId} is not bug! ");
            }

            bug.SetPriority(newBugPriority);
            return $"Bug with name {bug.Name} successfully changed priority to {newBugPriority}'!";
        }
    }
}