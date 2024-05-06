using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public CreateTeamCommand(IRepository repository)
            : base(repository)
        {
        }
        public CreateTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string name = CommandParameters[0];
            Repository.AddTeamIfNotExists(Repository.CreateTeam(name));
            return $"Team with name {name} added successfully!";
        }
    }
}