using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ListTasksWithAssigneeCommand : BaseCommand
    {
        public ListTasksWithAssigneeCommand(IRepository repository)
            : base(repository)
        {
        }
        public ListTasksWithAssigneeCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(0,2,$"{CommandType.ListAllTasks} (filterByStatus) (filterByAssignee)");
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks.Where(y => y.Assignee != null)).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks.Where(y=>y.Assignee!=null))).ToList();

            var orderedAndFilteredTasks = tasks;
            if (CommandParameters.Count == 1)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[0]);
                orderedAndFilteredTasks = orderedAndFilteredTasks.Where(x => x.Status== filterStatus).ToList();
            }
            if (CommandParameters.Count == 2)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[0]);
                IMember filterAssignee = Repository.GetMemberIfExists(CommandParameters[1]);
                orderedAndFilteredTasks = orderedAndFilteredTasks.Where(x=>x.Assignee==filterAssignee).Where(x => x.Status == filterStatus).ToList();
            }
            orderedAndFilteredTasks = orderedAndFilteredTasks.OrderBy(x => x.Name).ToList();
            if (orderedAndFilteredTasks.Count==0)
            {
                return "No tasks with assignee! ";
            }
            return $"{string.Join(Environment.NewLine, orderedAndFilteredTasks)}";
        }
    }
}