using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

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
            CheckParametersCount(ExpectedParameters, $"{CommandType.CreateTeam} 'teamName'");
            string name = CommandParameters[0];
            Repository.AddTeamIfNotExists(Repository.CreateTeam(name));
            return $"Team with name '{name}' added successfully!";
        }
    }
}