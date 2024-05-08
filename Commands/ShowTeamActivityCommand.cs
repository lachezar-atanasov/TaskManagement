﻿using System;
using TaskManagement.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Commands.Enums;
using TaskManagement.Exceptions;
using TaskManagement.Models.Contracts;
using TaskManagement.Commands.Abstract;

namespace TaskManagement.Commands
{
    public class ShowTeamActivityCommand : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowTeamActivityCommand(IRepository repository)
            : base(repository)
        {
        }
        public ShowTeamActivityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            CheckParametersCount(ExpectedParameters,$"{CommandType.ShowTeamActivity} 'teamName'");
            string teamName = CommandParameters[0];
            if (!Repository.TeamExists(teamName))
            {
                throw new InvalidUserInputException("Team with that name doesn't exists! ");
            }

            var searchedTeam = Repository.Teams.First(x => x.Name == teamName);
            var totalTeamActivityHistory = new List<IEventLogger>();
            totalTeamActivityHistory = totalTeamActivityHistory.Concat(searchedTeam.ActivityHistory.LogEvents).ToList();

            foreach (var board in searchedTeam.Boards)
            {
                totalTeamActivityHistory = totalTeamActivityHistory.Concat(board.ActivityHistory.LogEvents).ToList();
            }
            foreach (var member in searchedTeam.Members)
            {
                totalTeamActivityHistory = totalTeamActivityHistory.Concat(member.ActivityHistory.LogEvents).ToList();
            }

            if (totalTeamActivityHistory.Count==0)
            {
                throw new ArgumentException($"Team with name {teamName} have no logs yet! ");
            }

            return $"Team '{teamName}': {Environment.NewLine}" +
                   $"{string.Join(' ', totalTeamActivityHistory)}";
        }
    }
}