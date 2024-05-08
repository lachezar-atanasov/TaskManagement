using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class AssignTaskToMemberCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public AssignTaskToMemberCommand(IRepository repository)
            : base(repository)
        {
        }
        public AssignTaskToMemberCommand(IList<string> commandParameters, IRepository repository)
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
            foundMember.AddTask(foundTask);
            foundTask.AssignTo(foundMember);

            return $"Task with name {foundTask.Name} successfully assigned to {foundMember.Name}'!";
        }
    }
}