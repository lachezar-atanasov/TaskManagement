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

            IMember foundMember = Repository.Members.First(x => x.Name == memberToList);
            if (foundMember.ActivityHistory.LogEvents.All(x => x.Assigner?.Name != memberToList))
            {
                throw new ArgumentException($"Member with name {memberToList} have no logs yet! ");
            }
            
            IList<IEventLogger> memberTasksActivityHistory = foundMember.ActivityHistory.LogEvents
                .Where(x => x.Assigner?.Name == memberToList).ToList();
            var totalMemberActivityHistory =
                memberTasksActivityHistory.Concat(foundMember.ActivityHistory.LogEvents).ToList();
            return $"Member {memberToList}: {Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, totalMemberActivityHistory.OrderBy(x=>x.Time))}";
        }
    }
}