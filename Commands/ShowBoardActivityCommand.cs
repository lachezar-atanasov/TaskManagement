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
        private const int ExpectedParameters = 2;
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
            string teamName = CommandParameters[1];

            IBoard foundBoard = Repository.GetBoardIfExists(boardName, teamName);

            if (!foundBoard.ActivityHistory.LogEvents.Any())
            {
                throw new ArgumentException($"Board with name {boardName} have no logs yet! ");
            }

            return $"Board '{boardName}' activity history: {Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, foundBoard.ActivityHistory.LogEvents.OrderBy(x => x.Time))}";
        }
    }
}