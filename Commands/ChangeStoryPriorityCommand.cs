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
    public class ChangeStoryPriorityCommand : BaseCommand
    {
        private const int ExpectedParameters = 2;
        public ChangeStoryPriorityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ChangeStoryPriorityCommand(IList<string> commandParameters, IRepository repository)
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
            return $"Story with title '{story.Name}(id={story.Id})' successfully changed priority to '{newStoryPriority}'!";
        }
    }
}