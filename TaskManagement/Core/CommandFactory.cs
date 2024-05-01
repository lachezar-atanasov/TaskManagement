using OOP_Project_Telerik.Commands.Contracts;
using OOP_Project_Telerik.Commands.Enums;
using OOP_Project_Telerik.Core.Contracts;
using System;
using System.Collections.Generic;

namespace OOP_Project_Telerik.Core
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
                case CommandType.CreatePerson:
                    throw new NotImplementedException();
                case CommandType.ShowAllPeople:
                    throw new NotImplementedException();
                case CommandType.ShowPersonActivity:
                    throw new NotImplementedException();
                case CommandType.CreateTeam:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeams:
                    throw new NotImplementedException();
                case CommandType.ShowTeamActivity:
                    throw new NotImplementedException();
                case CommandType.CreateNewBoardInTeam:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeamMembers:
                    throw new NotImplementedException();
                case CommandType.CreateNewTask:
                    throw new NotImplementedException();
                case CommandType.ChangeBugDetail:
                    throw new NotImplementedException();
                case CommandType.ChangeStoryDetail:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedbackDetail:
                    throw new NotImplementedException();
                case CommandType.AssignTaskToPerson:
                    throw new NotImplementedException();
                case CommandType.UnassignTaskToPerson:
                    throw new NotImplementedException();
                case CommandType.ListSubTask:
                    throw new NotImplementedException();
                case CommandType.ListTasksWithAsignee:
                    throw new NotImplementedException();
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