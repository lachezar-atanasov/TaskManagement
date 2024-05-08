using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class CreateNewStoryInBoardCommand : BaseCommand
    {
        private const int ExpectedParameters = 6;
        private readonly string _storyPriorities = $"{Priority.Low}, {Priority.Medium}, {Priority.High}";
        private readonly string _storySizes = $"{Size.Small}, {Size.Medium}, {Size.Large}";
        public CreateNewStoryInBoardCommand(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewStoryInBoardCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters, $"{CommandType.CreateNewStoryInBoard} 'storyName' 'storyDescription' 'storySize({_storySizes})' 'storyPriority({_storyPriorities})' 'boardName' 'teamName'");
            string storyName = CommandParameters[0];
            string storyDesc = CommandParameters[1];
            Size storySize = ParseHelper.ParseSizeParameter(CommandParameters[2]);
            Priority storyPriority = ParseHelper.ParsePriorityParameter(CommandParameters[3]);
            string boardName = CommandParameters[4];
            string teamName = CommandParameters[5];

            var foundBoard = Repository.GetBoardIfExists(boardName, teamName);
            foundBoard.AddTask(Repository.CreateStory(storyName,storyDesc,storyPriority, storySize));

            return $"Story with name {storyName} added successfully to board '{boardName}'!";
        }
    }
}