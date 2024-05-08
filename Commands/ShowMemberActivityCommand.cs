using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Models.Contracts;
using TaskManagement.Commands.Abstract;

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
            CheckParametersCount(ExpectedParameters, $"{CommandType.ShowMemberActivity} 'memberName'");
            string memberName = CommandParameters[0];
            IMember foundMember = Repository.GetMemberIfExists(memberName);

            IList<IEventLogger> memberTasksActivityHistory = foundMember.ActivityHistory.LogEvents
                .Where(x => x.Assigner?.Name == memberName).ToList();
            var totalMemberActivityHistory =
                memberTasksActivityHistory.Concat(foundMember.ActivityHistory.LogEvents).ToList();
            if (memberTasksActivityHistory.Count == 0)
            {
                throw new ArgumentException($"Member with name {memberName} have no logs yet! ");
            }
            return $"Member '{memberName}': {Environment.NewLine}" +
                   $"{string.Join(Environment.NewLine, totalMemberActivityHistory.OrderBy(x => x.Time))}";
        }
    }
}