using TaskManagement.Commands.Contracts;
using TaskManagement.Commands.Enums;
using TaskManagement.Core.Contracts;
using System;
using System.Collections.Generic;
using TaskManagement.Commands;

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
            string[] arguments = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CommandType commandType = ParseCommandType(arguments[0]);
            List<string> commandParams = ExtractCommandParameters(arguments);

            switch(commandType)
            {
                case CommandType.AddMember:
                    return new AddNewMemberCommand(commandParams, _repository);
                case CommandType.ShowAllMembers:
                    return new ShowAllMembersCommand(commandParams, _repository);
                case CommandType.ShowMemberActivity:
                    return new ShowMemberActivityCommand(commandParams, _repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParams, _repository);
                case CommandType.ShowAllTeams:
                    return new ShowAllTeamsCommand(commandParams, _repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParams, _repository);
                case CommandType.AddMemberToTeam:
                    return new AddMemberToTeamCommand(commandParams, _repository);
                case CommandType.ShowAllTeamMembers:
                    return new ShowAllTeamMembersCommand(commandParams, _repository);
                case CommandType.CreateNewBoardInTeam:
                    return new CreateNewBoardInTeamCommand(commandParams, _repository);
                case CommandType.CreateNewBugInBoard:
                    return new CreateNewBugInBoard(commandParams, _repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriority(commandParams, _repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverity(commandParams, _repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatus(commandParams, _repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRating(commandParams, _repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatus(commandParams, _repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriority(commandParams, _repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySize(commandParams, _repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatus(commandParams, _repository);
                case CommandType.ListAllTasks:
                    return new ListAllTasks(commandParams, _repository);
                case CommandType.AssignTaskToMember:
                    return new AssignTaskToMember(commandParams, _repository);
                case CommandType.UnassignTaskFromMember:
                    return new UnassignTaskFromMember(commandParams, _repository);
                case CommandType.ListTasksWithAssignee:
                    return new ListTasksWithAssignee(commandParams, _repository);
                case CommandType.ListBugs:
                    return new ListBugs(commandParams, _repository);
                case CommandType.ListFeedbacks:
                    return new ListFeedbacks(commandParams, _repository);
                case CommandType.ListStories:
                    return new ListStories(commandParams, _repository);
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