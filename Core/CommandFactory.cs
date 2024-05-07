﻿using TaskManagement.Commands.Contracts;
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
                    return new CreateNewBugInBoard(commandParams, _repository);
                case CommandType.CreateNewFeedbackInBoard:
                    return new CreateNewFeedbackInBoard(commandParams, _repository);
                case CommandType.CreateNewStoryInBoard:
                    return new CreateNewStoryInBoard(commandParams, _repository);
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
                case CommandType.AddCommentToTask:
                    return new AddCommentToTask(commandParams, _repository);
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