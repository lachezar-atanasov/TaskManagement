using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;

namespace TaskManagement.Commands
{
    public class ShowAllMembersCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
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
            return $"List of all members: {String.Join(' ',Repository.Members)}";
        }
    }
}