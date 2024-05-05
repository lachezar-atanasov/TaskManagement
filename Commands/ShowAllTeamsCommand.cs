using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Commands
{
    public class ShowAllTeamsCommand : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public ShowAllTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        public ShowAllTeamsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            return $"List of all teams: {String.Join(' ',Repository.Teams.Select(x=>x.Name).ToList())}";
        }
    }
}