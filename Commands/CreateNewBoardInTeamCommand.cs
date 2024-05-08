using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

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
            CheckParametersCount(ExpectedParameters, $"{CommandType.CreateNewBoardInTeam} 'boardName' 'teamName'");

            string boardName = CommandParameters[0];
            string teamName = CommandParameters[1];

            var foundTeam = Repository.GetTeamIfExists(teamName);

            foundTeam.AddBoardIfNotExists(Repository.CreateBoard(boardName));

            return $"Board with name '{boardName}' added successfully to team '{teamName}'!";
        }
    }
}