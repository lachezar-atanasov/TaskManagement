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
    public class ChangeStorySizeCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStorySizeCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStorySizeCommand(IList<string> commandParameters, IRepository repository)
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