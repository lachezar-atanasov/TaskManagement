using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ListAllTasks : BaseCommand
    {
        private const int ExpectedParameters = 0;
        public ListAllTasks(IRepository repository)
            : base(repository)
        {
        }
        public ListAllTasks(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            var tasks = Repository.Teams.SelectMany(x => x.Boards).SelectMany(x=>x.Tasks).ToList();
            tasks = tasks.Concat(Repository.Members.SelectMany(x => x.Tasks)).ToList();
            return $"{string.Join(Environment.NewLine,tasks)}";
        }
    }
}