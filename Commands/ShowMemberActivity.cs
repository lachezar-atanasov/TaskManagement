using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ShowMemberActivity : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowMemberActivity(IRepository repository)
            : base(repository)
        {
        }
        public ShowMemberActivity(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            return $"List of all members: {String.Join(' ',Repository.Members)}";
        }
    }
}