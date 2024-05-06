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
    public class AssignTaskToMember : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public AssignTaskToMember(IRepository repository)
            : base(repository)
        {
        }
        public AssignTaskToMember(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.AssignTaskToMember} 'taskId' 'memberName'");
            int taskId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            string memberName = CommandParameters[1];

            var foundTask = Repository.GetTaskById(taskId);
            var foundMember = Repository.GetMemberIfExists(memberName);
            foundTask.AssignTo(foundMember);

            return $"Task with name {foundTask.Name} successfully assigned to {foundMember.Name}'!";
        }
    }
}