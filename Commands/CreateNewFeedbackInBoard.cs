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
    public class CreateNewFeedbackInBoard : BaseCommand
    {
        private const int ExpectedParameters = 4;
        public CreateNewFeedbackInBoard(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewFeedbackInBoard(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.CreateNewFeedbackInBoard} 'feedbackName' 'feedbackDescription' 'boardName' 'teamName'");
            string feedbackName = CommandParameters[0];
            string feedbackDescription = CommandParameters[1];
            string boardName = CommandParameters[2];
            string teamName = CommandParameters[3];

            var foundBoard = Repository.GetBoardIfExists(boardName,teamName);
            foundBoard.AddTask(Repository.CreateFeedback(feedbackName,feedbackDescription));

            return $"Feedback with name {feedbackName} added successfully to board '{boardName}'!";
        }
    }
}