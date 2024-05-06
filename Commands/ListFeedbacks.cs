﻿using System;
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
    public class ListFeedbacks : BaseCommand
    {
        public ListFeedbacks(IRepository repository)
            : base(repository)
        {
        }
        public ListFeedbacks(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(0,3,$"{CommandType.ListFeedbacks} (sortBy[Title,Rating]) (filterByStatus) (filterByAssignee)");
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks.Where(y => y.Assignee != null)).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks.Where(y=>y.Assignee!=null))).ToList();

            var orderedAndFilteredBugs = tasks.OfType<IFeedback>().ToList();
            if (CommandParameters.Count > 0)
            {
                string orderBy = CommandParameters[0].ToLower();
                switch (orderBy)
                {
                    case "title":
                        orderedAndFilteredBugs = orderedAndFilteredBugs.OrderBy(x => x.Name).ToList();
                        break;
                    case "rating":
                        orderedAndFilteredBugs = orderedAndFilteredBugs.OrderBy(x => x.Rating).ToList();
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
            return $"{string.Join(Environment.NewLine, orderedAndFilteredBugs)}";
        }
    }
}