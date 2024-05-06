using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;

namespace TaskManagement.Commands
{
    public class ShowAllTeamBoardsCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowAllTeamBoardsCommand(IRepository repository)
            : base(repository)
        {
        }

        public ShowAllTeamBoardsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ShowAllTeamBoards} 'teamName'");
            string teamName = CommandParameters[0];

            var foundTeam = Repository.GetTeamIfExists(teamName);
            return $"List of all board names in team '{teamName}': {String.Join(' ', foundTeam.Boards.Select(x=>x.Name).ToList())}";
        }
    }
}