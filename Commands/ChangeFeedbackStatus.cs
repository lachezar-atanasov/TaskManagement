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
    public class ChangeFeedbackStatus : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeFeedbackStatus(IRepository repository)
            : base(repository)
        {
        }
        public ChangeFeedbackStatus(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeFeedbackStatus} 'storyId' " +
                                                    $"'newStatus({Status.New},{Status.Unscheduled}, {Status.Scheduled}, {Status.Done})'");
            int storyId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Status newFeedbackStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);

            var storyToChange = Repository.GetTaskById(storyId);
            if (storyToChange is not IFeedback feedback)
            {
                throw new InvalidUserInputException($"Task with id {storyId} is not story! ");
            }

            feedback.SetStatus(newFeedbackStatus);
            return $"Feedback with title {feedback.Name}(id={feedback.Id}) successfully changed status to {newFeedbackStatus}'!";
        }
    }
}