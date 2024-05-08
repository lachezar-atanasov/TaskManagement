using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class CreateNewFeedbackInBoardCommand : BaseCommand
    {
        private const int ExpectedParameters = 4;
        public CreateNewFeedbackInBoardCommand(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewFeedbackInBoardCommand(IList<string> commandParameters, IRepository repository)
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

            return $"Feedback with name '{feedbackName}' added successfully to board '{boardName}'!";
        }
    }
}