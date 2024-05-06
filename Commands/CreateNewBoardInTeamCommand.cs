using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class CreateNewBoardInTeamCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public CreateNewBoardInTeamCommand(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewBoardInTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);

            string boardName = CommandParameters[0];
            string teamName = CommandParameters[1];

            var foundTeam = Repository.GetTeamIfExists(teamName);

            foundTeam.AddBoardIfNotExists(Repository.CreateBoard(boardName));

            return $"Board with name {boardName} added successfully to team '{teamName}'!";
        }
    }
}