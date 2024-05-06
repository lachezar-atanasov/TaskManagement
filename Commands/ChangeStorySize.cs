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
    public class ChangeStorySize : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStorySize(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStorySize(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ChangeStorySize} 'storyId' " +
                                                    $"'newSize({Size.Small},{Size.Medium}, {Size.Large})'");
            int storyId = ParseHelper.ParseIntParameter(CommandParameters[0],"ID");
            Size newStorySize = ParseHelper.ParseSizeParameter(CommandParameters[1]);

            var storyToChange = Repository.GetTaskById(storyId);
            if (storyToChange is not IStory story)
            {
                throw new InvalidUserInputException($"Task with id {storyId} is not story! ");
            }

            story.SetSize(newStorySize);
            return $"Story with title {story.Name}(id={story.Id}) successfully changed size to {newStorySize}'!";
        }
    }
}