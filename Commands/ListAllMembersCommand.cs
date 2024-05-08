using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ListAllMembersCommand : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public ListAllMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public ListAllMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            var members = Repository.Members.Select(x => x.Name).ToList();
            if (members.Count == 0)
            {
                return "No members yet! ";
            }
            return $"List of all members: {string.Join(' ', members)}";
        }
    }
}