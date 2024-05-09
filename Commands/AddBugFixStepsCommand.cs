using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class AddBugFixStepsCommand : BaseCommand
    {
        public AddBugFixStepsCommand(IRepository repository)
            : base(repository)
        {
        }
        public AddBugFixStepsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(2,100, $"{CommandType.AddBugFixSteps} 'bugId' \"(step);(step);(step)\"");
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            List<string> stepsToAdd = CommandParameters[1].Split(';',StringSplitOptions.RemoveEmptyEntries).ToList();

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Task with id {bugId} is not bug! ");
            }

            bug.AddSteps(stepsToAdd);
            return $"Successfully added steps for fix to bug with name: '{bug.Name}'! ";
        }
    }
}