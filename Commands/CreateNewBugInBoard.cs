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
    public class CreateNewBugInBoard : BaseCommand
    {
        private const int ExpectedParameters = 6;
        public CreateNewBugInBoard(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewBugInBoard(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string bugName = CommandParameters[0];
            string bugDescription = CommandParameters[1];
            Severity bugSeverity = ParseHelper.ParseSeverityParameter(CommandParameters[2]);
            Priority bugPriority = ParseHelper.ParsePriorityParameter(CommandParameters[3]);
            string boardName = CommandParameters[4];
            string teamName = CommandParameters[5];

            var foundBoard = Repository.GetBoardIfExists(boardName,teamName);
            foundBoard.AddTask(Repository.CreateBug(bugName,bugDescription, bugSeverity, bugPriority));

            return $"Bug with name {bugName} added successfully to board '{boardName}'!";
        }
    }
}