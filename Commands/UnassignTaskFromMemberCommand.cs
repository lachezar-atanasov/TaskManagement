using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class UnassignTaskFromMemberCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public UnassignTaskFromMemberCommand(IRepository repository)
            : base(repository)
        {
        }
        public UnassignTaskFromMemberCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.UnassignTaskFromMember} 'taskId'");
            int taskId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            string memberName = CommandParameters[1];

            var foundTask = Repository.GetTaskById(taskId);
            string? currentAssignee = foundTask.Assignee?.Name;
            foundTask.Unassign();

            return $"Task with name {foundTask.Name} successfully unassigned from {currentAssignee}'!";
        }
    }
}