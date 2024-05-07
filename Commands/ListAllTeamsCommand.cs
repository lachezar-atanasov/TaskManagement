using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Commands
{
    public class ListAllTeamsCommand : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public ListAllTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        public ListAllTeamsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            var teams = Repository.Teams.Select(x => x.Name).ToList();
            if (teams.Count == 0)
            {
                return $"There is no teams yet! ";
            }
            return $"List of all teams: {String.Join(' ', teams)}";
        }
    }
}