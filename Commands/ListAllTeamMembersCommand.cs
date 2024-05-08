using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ListAllTeamMembersCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ListAllTeamMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public ListAllTeamMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ListAllTeamMembers} 'teamName'");
            string teamName = CommandParameters[0];

            var foundTeam = Repository.GetTeamIfExists(teamName);
            var teamMembers = foundTeam.Members.Select(x => x.Name).ToList();
            if (teamMembers.Count==0)
            {
                return $"Team '{teamName} has no members yet! '";
            }
            return $"List of all member names in team '{teamName}': {string.Join(' ', teamMembers)}";
        }
    }
}