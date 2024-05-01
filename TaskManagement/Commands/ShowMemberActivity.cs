using System;
using OOP_Project_Telerik.Core.Contracts;
using System.Collections.Generic;
using OOP_Project_Telerik.Models.Contracts;

namespace OOP_Project_Telerik.Commands
{
    public class ShowMemberActivity : BaseCommand
    {
        private const int ExpectedParameters = 1;
        public ShowMemberActivity(IRepository repository)
            : base(repository)
        {
        }
        public ShowMemberActivity(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            return $"List of all members: {String.Join(' ',Repository.Members)}";
        }
    }
}