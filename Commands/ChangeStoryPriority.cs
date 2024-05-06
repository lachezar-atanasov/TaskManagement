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
    public class ChangeStoryPriority : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStoryPriority(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStoryPriority(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeStoryPriority} 'storyId' " +
                                                    $"'newPriority({Priority.Low},{Priority.Medium}, {Priority.High})'");
            int storyId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Priority newStoryPriority = ParseHelper.ParsePriorityParameter(CommandParameters[1]);

            var storyToChange = Repository.GetTaskById(storyId);
            if (storyToChange is not IStory story)
            {
                throw new InvalidUserInputException($"Task with id {storyId} is not story! ");
            }

            story.SetPriority(newStoryPriority);
            return $"Story with title {story.Name}(id={story.Id}) successfully changed priority to {newStoryPriority}'!";
        }
    }
}