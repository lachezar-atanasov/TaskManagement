using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class AddMemberToTeamCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public AddMemberToTeamCommand(IRepository repository)
            : base(repository)
        {
        }
        public AddMemberToTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string memberName = CommandParameters[0];
            string teamName = CommandParameters[1];
            Repository.CheckMemberExists(memberName);
            Repository.CheckTeamExists(teamName);

            var foundTeam = Repository.Teams.First(x => x.Name == teamName);
            var foundMember = Repository.Members.First(x => x.Name == memberName);
            foundTeam.AddMember(foundMember);

            return $"Member '{memberName}' successfully added to team '{teamName}'";
        }
    }
}