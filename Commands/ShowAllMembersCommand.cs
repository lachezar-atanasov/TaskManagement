using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Commands
{
    public class ShowAllMembersCommand : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public ShowAllMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public ShowAllMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            return $"List of all members: {String.Join(' ',Repository.Members.Select(x=>x.Name).ToList())}";
        }
    }
}