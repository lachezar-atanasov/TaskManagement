using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ShowMemberActivityCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowMemberActivityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ShowMemberActivityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string memberName = CommandParameters[0];
            Repository.CheckMemberExists(memberName);

            IMember foundMember = Repository.Members.First(x => x.Name == memberName);
            if (foundMember.ActivityHistory.LogEvents.All(x => x.Assigner?.Name != memberName))
            {
                throw new ArgumentException($"Member with name {memberName} have no logs yet! ");
            }

            IList<IEventLogger> memberTasksActivityHistory = foundMember.ActivityHistory.LogEvents
                .Where(x => x.Assigner?.Name == memberName).ToList();
            var totalMemberActivityHistory =
                memberTasksActivityHistory.Concat(foundMember.ActivityHistory.LogEvents).ToList();
            return $"Member {memberName}: {Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, totalMemberActivityHistory.OrderBy(x => x.Time))}";
        }
    }
}