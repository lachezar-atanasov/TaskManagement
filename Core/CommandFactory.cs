using TaskManagement.Commands.Contracts;
using TaskManagement.Commands.Enums;
using TaskManagement.Core.Contracts;
using System;
using System.Collections.Generic;
using TaskManagement.Commands;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text.RegularExpressions;

namespace TaskManagement.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository _repository;
        public CommandFactory(IRepository repository)
        {
            _repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            string[] arguments = Regex.Split(commandLine, @"\s(?=(?:[^""]*""[^""]*"")*[^""]*$)");
            CommandType commandType = ParseCommandType(arguments[0]);
            List<string> commandParams = ExtractCommandParameters(arguments);

            switch(commandType)
            {
                case CommandType.Help:
                    return new HelpCommand(commandParams, _repository);
                case CommandType.AddMember:
                    return new AddNewMemberCommand(commandParams, _repository);
                case CommandType.ListAllMembers:
                    return new ListAllMembersCommand(commandParams, _repository);
                case CommandType.ListAllTeamBoards:
                    return new ListAllTeamBoardsCommand(commandParams, _repository);
                case CommandType.ShowMemberActivity:
                    return new ShowMemberActivityCommand(commandParams, _repository);
                case CommandType.ShowBoardActivity:
                    return new ShowBoardActivityCommand(commandParams, _repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParams, _repository);
                case CommandType.ListAllTeams:
                    return new ListAllTeamsCommand(commandParams, _repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParams, _repository);
                case CommandType.AddMemberToTeam:
                    return new AddMemberToTeamCommand(commandParams, _repository);
                case CommandType.ListAllTeamMembers:
                    return new ListAllTeamMembersCommand(commandParams, _repository);
                case CommandType.CreateNewBoardInTeam:
                    return new CreateNewBoardInTeamCommand(commandParams, _repository);
                case CommandType.CreateNewBugInBoard:
                    return new CreateNewBugInBoardCommand(commandParams, _repository);
                case CommandType.CreateNewFeedbackInBoard:
                    return new CreateNewFeedbackInBoardCommand(commandParams, _repository);
                case CommandType.CreateNewStoryInBoard:
                    return new CreateNewStoryInBoardCommand(commandParams, _repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriorityCommand(commandParams, _repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverityCommand(commandParams, _repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatusCommand(commandParams, _repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRatingCommand(commandParams, _repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatusCommand(commandParams, _repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriorityCommand(commandParams, _repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySizeCommand(commandParams, _repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatusCommand(commandParams, _repository);
                case CommandType.ListAllTasks:
                    return new ListAllTasksCommand(commandParams, _repository);
                case CommandType.AssignTaskToMember:
                    return new AssignTaskToMemberCommand(commandParams, _repository);
                case CommandType.UnassignTaskFromMember:
                    return new UnassignTaskFromMemberCommand(commandParams, _repository);
                case CommandType.ListTasksWithAssignee:
                    return new ListTasksWithAssigneeCommand(commandParams, _repository);
                case CommandType.ListBugs:
                    return new ListBugsCommand(commandParams, _repository);
                case CommandType.ListFeedbacks:
                    return new ListFeedbacksCommand(commandParams, _repository);
                case CommandType.ListStories:
                    return new ListStoriesCommand(commandParams, _repository);
                case CommandType.AddCommentToTask:
                    return new AddCommentToTaskCommand(commandParams, _repository);
                default:
                    throw new InvalidOperationException("No such command");
            }
        }



        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);
            return result;
        }

        private List<String> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}