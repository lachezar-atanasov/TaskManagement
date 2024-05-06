using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Commands
{
    public class UnassignTaskFromMember : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public UnassignTaskFromMember(IRepository repository)
            : base(repository)
        {
        }
        public UnassignTaskFromMember(IList<string> commandParameters, IRepository repository)
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