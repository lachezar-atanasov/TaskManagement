﻿using System;
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
    public class ChangeBugPriority : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeBugPriority(IRepository repository)
            : base(repository)
        {
        }
        public ChangeBugPriority(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            int bugId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Priority newBugPriority = ParseHelper.ParsePriorityParameter(CommandParameters[1]);

            var bugToChange = Repository.GetTaskById(bugId);
            if (bugToChange is not IBug bug)
            {
                throw new InvalidUserInputException($"Bug with id {bugId} is not bug! ");
            }

            bug.SetPriority(newBugPriority);
            return $"Bug with name {bug.Name} successfully changed priority to {newBugPriority}'!";
        }
    }
}