using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Helpers;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeFeedbackStatusCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeFeedbackStatusCommand(IList<string> commandParameters, IRepository repository)
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
            return $"Feedback with title '{feedback.Name}(id={feedback.Id})' successfully changed status to '{newFeedbackStatus}'!";
        }
    }
}