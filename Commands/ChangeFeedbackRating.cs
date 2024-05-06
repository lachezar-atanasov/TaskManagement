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
    public class ChangeFeedbackRating : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeFeedbackRating(IRepository repository)
            : base(repository)
        {
        }
        public ChangeFeedbackRating(IList<string> commandParameters, IRepository repository)
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
            return $"Feedback with title {feedback.Name}(id={feedback.Id}) successfully changed status to {newRating}'!";
        }
    }
}