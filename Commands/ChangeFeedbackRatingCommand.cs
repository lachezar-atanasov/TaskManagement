using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ChangeFeedbackRatingCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeFeedbackRatingCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeFeedbackRatingCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeFeedbackRating} 'storyId' 'newRating(integer)'");
            int storyId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            int newRating = ParseHelper.ParseIntParameter(CommandParameters[1],"Rating");

            var storyToChange = Repository.GetTaskById(storyId);
            if (storyToChange is not IFeedback feedback)
            {
                throw new InvalidUserInputException($"Task with id {storyId} is not story! ");
            }

            feedback.SetRating(newRating);
            return $"Feedback with title '{feedback.Name}(id={feedback.Id})' successfully changed status to '{newRating}'!";
        }
    }
}