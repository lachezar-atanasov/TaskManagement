using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class CreateTeam : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public CreateTeam(IRepository repository)
            : base(repository)
        {
        }
        public CreateTeam(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string name = CommandParameters[0];
            Repository.AddTeam(Repository.CreateTeam(name));
            return $"Team with name {name} added successfully!";
        }
    }
}