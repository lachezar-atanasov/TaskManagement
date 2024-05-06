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
    public class ListStories : BaseCommand
    {
        public ListStories(IRepository repository)
            : base(repository)
        {
        }
        public ListStories(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(0,3,$"{CommandType.ListStories} (sortBy[Title,Priority,Size]) (filterByStatus) (filterByAssignee)");
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks.Where(y => y.Assignee != null)).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks.Where(y=>y.Assignee!=null))).ToList();

            var orderedAndFilteredStories = tasks.OfType<IStory>().ToList();
            if (CommandParameters.Count > 0)
            {
                string orderBy = CommandParameters[0].ToLower();
                switch (orderBy)
                {
                    case "title":
                        orderedAndFilteredStories = orderedAndFilteredStories.OrderBy(x => x.Name).ToList();
                        break;
                    case "priority":
                        orderedAndFilteredStories = orderedAndFilteredStories.OrderBy(x => x.Priority).ToList();
                        break;
                    case "size":
                        orderedAndFilteredStories = orderedAndFilteredStories.OrderBy(x => x.Size).ToList();
                        break;
                }
            }
            if (CommandParameters.Count == 2)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);
                orderedAndFilteredStories = orderedAndFilteredStories.Where(x => x.Status== filterStatus).ToList();
            }
            if (CommandParameters.Count == 3)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);
                IMember filterMember = Repository.GetMemberIfExists(CommandParameters[2]);
                orderedAndFilteredStories = orderedAndFilteredStories.Where(x=>x.Assignee==filterMember).Where(x => x.Status == filterStatus).ToList();
            }
            return $"{string.Join(Environment.NewLine, orderedAndFilteredStories)}";
        }
    }
}