using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ListAllTasksCommand : BaseCommand
    {
        public ListAllTasksCommand(IRepository repository)
            : base(repository)
        {
        }
        public ListAllTasksCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(0,1,$"{CommandType.ListAllTasks} (filterByTitle)");
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks)).ToList();
            
            var orderedTasksAndFiltered = tasks.OrderBy(x => x.Name).ToList();
            if (CommandParameters.Count == 1)
            {
                var filterTitle = CommandParameters[0];
                orderedTasksAndFiltered = orderedTasksAndFiltered.Where(x => x.Name.Contains(filterTitle)).ToList();
            }

            if (orderedTasksAndFiltered.Count==0)
            {
                return ($"No tasks yet! ");
            }
            
            return $"{string.Join(Environment.NewLine, orderedTasksAndFiltered)}";
        }
    }
}