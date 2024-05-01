using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
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
            CheckParametersCount(ExpectedParameters);
            string memberToList = CommandParameters[0];
            if (!Repository.MemberExists(memberToList))
            {
                throw new InvalidUserInputException("Member with that name doesn't exists! ");
            }
            if (ActivityHistory.LogEvents.All(x => x.Member?.Name != memberToList))
            {
                throw new ArgumentException($"Member with name {memberToList} have no logs yet! ");
            }

            return $"Member {memberToList}: {Environment.NewLine}" +
                   $"{String.Join(' ',ActivityHistory.LogEvents.Where(x=>x.Member?.Name==memberToList).ToList())}";
        }
    }
}