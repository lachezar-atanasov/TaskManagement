using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ShowBoardActivityCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowBoardActivityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ShowBoardActivityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters);
            string boardName = CommandParameters[0];
            Repository.CheckBoardExists(boardName);

            IBoard foundBoard = Repository.Teams.SelectMany(x => x.Boards).First(x => x.Name == boardName);
            var boardTasksEvents = foundBoard.Tasks.SelectMany(x => x.ActivityHistory.LogEvents);
            var totalBoardEvents = boardTasksEvents.Concat(foundBoard.ActivityHistory.LogEvents);
            var eventLoggers = totalBoardEvents.ToList();

            if (!eventLoggers.Any())
            {
                throw new ArgumentException($"Board with name {boardName} have no logs yet! ");
            }

            return $"Board '{boardName}' activity history: {Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, eventLoggers.OrderBy(x => x.Time))}";
        }
    }
}