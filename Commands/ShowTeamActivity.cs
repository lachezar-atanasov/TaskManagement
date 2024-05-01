using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ShowTeamActivity : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowTeamActivity(IRepository repository)
            : base(repository)
        {
        }
        public ShowTeamActivity(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string teamName = CommandParameters[0];
            if (!Repository.TeamExists(teamName))
            {
                throw new InvalidUserInputException("Team with that name doesn't exists! ");
            }
            if (Repository.Teams.All(x => x..Name != teamName))
            {
                throw new ArgumentException($"Team with name {teamName} have no logs yet! ");
            }

            return $"Team '{teamName}': {Environment.NewLine}" +
                   $"{String.Join(' ', ActivityHistory.LogEvents.Where(x => x.Board?.Team.Name == teamName).ToList())}";
        }
    }
}