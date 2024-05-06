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
    public class ChangeStoryStatus : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStoryStatus(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStoryStatus(IList<string> commandParameters, IRepository repository)
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