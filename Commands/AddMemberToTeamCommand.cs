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

            var foundTeam = Repository.GetTeamIfExists(teamName);
            var foundMember = Repository.GetMemberIfExists(memberName);
            foundTeam.AddMemberIfNotExists(foundMember);

            return $"Member '{memberName}' successfully added to team '{teamName}'";
        }
    }
}