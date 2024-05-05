using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Commands
{
    public class ShowAllTeamMembersCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowAllTeamMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public ShowAllTeamMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string teamName = CommandParameters[0];
            Repository.CheckTeamExists(teamName);
            return $"List of all member names in team '{teamName}': {String.Join(' ',Repository.Members.Select(x=>x.Name).ToList())}";
        }
    }
}