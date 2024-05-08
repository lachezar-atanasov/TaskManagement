using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ListAllTeamBoardsCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ListAllTeamBoardsCommand(IRepository repository)
            : base(repository)
        {
        }

        public ListAllTeamBoardsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ListAllTeamBoards} 'teamName'");
            string teamName = CommandParameters[0];

            var foundTeam = Repository.GetTeamIfExists(teamName);
            var teamBoards = foundTeam.Boards.Select(x => x.Name).ToList();
            if (teamBoards.Count==0)
            {
                return $"Team {foundTeam.Name} has no boards yet! ";
            }
            return $"List of all board names in team '{teamName}': {String.Join(' ', teamBoards)}";
        }
    }
}