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
    public class ChangeStoryStatusCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStoryStatusCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStoryStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeStoryStatus} 'storyId' " +
                                                    $"'newStatus({Status.NotDone},{Status.InProgress}, {Status.Done})'");
            int storyId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Status newStoryStatus = ParseHelper.ParseStatusParameter(CommandParameters[1]);

            var storyToChange = Repository.GetTaskById(storyId);
            if (storyToChange is not IStory story)
            {
                throw new InvalidUserInputException($"Task with id {storyId} is not story! ");
            }

            story.SetStatus(newStoryStatus);
            return $"Story with title {story.Name}(id={story.Id}) successfully changed status to {newStoryStatus}'!";
        }
    }
}