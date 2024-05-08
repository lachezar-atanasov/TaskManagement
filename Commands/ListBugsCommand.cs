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
    public class ListBugsCommand : BaseCommand
    {
        public ListBugsCommand(IRepository repository)
            : base(repository)
        {
        }
        public ListBugsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(0,3,$"{CommandType.ListBugs} (sortBy[Title,Priority,Severity]) (filterByStatus) (filterByAssignee)");
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks.Where(y => y.Assignee != null)).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks.Where(y=>y.Assignee!=null))).ToList();

            var orderedAndFilteredBugs = tasks.OfType<IBug>().ToList();
            if (CommandParameters.Count > 0)
            {
                string orderBy = CommandParameters[0].ToLower();
                switch (orderBy)
                {
                    case "title":
                        orderedAndFilteredBugs = orderedAndFilteredBugs.OrderBy(x => x.Name).ToList();
                        break;
                    case "priority":
                        orderedAndFilteredBugs = orderedAndFilteredBugs.OrderBy(x => x.Priority).ToList();
                        break;
                    case "severity":
                        orderedAndFilteredBugs = orderedAndFilteredBugs.OrderBy(x => x.Severity).ToList();
                        break;
                }
            }
            if (CommandParameters.Count == 2)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);
                orderedAndFilteredBugs = orderedAndFilteredBugs.Where(x => x.Status== filterStatus).ToList();
            }
            if (CommandParameters.Count == 3)
            {
                Status filterStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);
                IMember filterMember = Repository.GetMemberIfExists(CommandParameters[2]);
                orderedAndFilteredBugs = orderedAndFilteredBugs.Where(x=>x.Assignee==filterMember).Where(x => x.Status == filterStatus).ToList();
            }
            if (orderedAndFilteredBugs.Count == 0)
            {
                return "No bugs with that filter! ";
            }
            return $"{string.Join(Environment.NewLine, orderedAndFilteredBugs)}";
        }
    }
}