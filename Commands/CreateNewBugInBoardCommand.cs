using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using TaskManagement.Commands.Enums;
using TaskManagement.Helpers;
using TaskManagement.Models.Enums;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class CreateNewBugInBoardCommand : BaseCommand
    {
        private const int ExpectedParameters = 6;
        private readonly string _bugPriorities = $"{Priority.Low}, {Priority.Medium}, {Priority.High}";
        private readonly string _bugSeverities = $"{Severity.Minor}, {Severity.Major}, {Severity.Critical}";
        public CreateNewBugInBoardCommand(IRepository repository)
            : base(repository)
        {
        }
        public CreateNewBugInBoardCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters, $"{CommandType.CreateNewBugInBoard} 'bugName' 'bugDescription' 'bugSeverity({_bugSeverities})' 'bugPriority({_bugPriorities})' 'boardName' 'teamName'");
            string bugName = CommandParameters[0];
            string bugDescription = CommandParameters[1];
            Severity bugSeverity = ParseHelper.ParseSeverityParameter(CommandParameters[2]);
            Priority bugPriority = ParseHelper.ParsePriorityParameter(CommandParameters[3]);
            string boardName = CommandParameters[4];
            string teamName = CommandParameters[5];

            var foundBoard = Repository.GetBoardIfExists(boardName,teamName);
            foundBoard.AddTask(Repository.CreateBug(bugName,bugDescription, bugSeverity, bugPriority));

            return $"Bug with name {bugName} added successfully to board '{boardName}'!";
        }
    }
}