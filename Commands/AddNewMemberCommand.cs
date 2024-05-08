using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public  class AddNewMemberCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public AddNewMemberCommand(IRepository repository) 
            : base(repository)
        {
        }

        public AddNewMemberCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.AddMember} 'memberName'");

            string name = CommandParameters[0];

            Repository.AddMemberIfNotExists(Repository.CreateMember(name));
            return $"Member with name '{name}' added successfully!";
        }
    }
}
