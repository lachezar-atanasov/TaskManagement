using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class AddCommentToTaskCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public AddCommentToTaskCommand(IRepository repository)
            : base(repository)
        {
        }
        public AddCommentToTaskCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.AddCommentToTask} 'taskId' 'authorName' 'commentMessage'");
            int taskId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            string authorName = CommandParameters[1];
            string commentMessage = CommandParameters[2];

            var foundTask = Repository.GetTaskById(taskId);
            var foundMember = Repository.GetMemberIfExists(authorName);
            foundTask.AddComment(Repository.CreateComment(foundMember.Name, commentMessage));

            return $"Successfully added comment to task '{foundTask.Name}(id={foundTask.Id}')! ";
        }
    }
}