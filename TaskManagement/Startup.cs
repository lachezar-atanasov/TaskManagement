using System;
using OOP_Project_Telerik.Core;
using OOP_Project_Telerik.Core.Contracts;

namespace OOP_Project_Telerik
{
    public class Startup
    {
            static void Main()
            {
                IRepository repository = new Repository();
                ICommandFactory commandFactory = new CommandFactory(repository);
                IEngine engine = new Engine(commandFactory);
                engine.Start();
            }
        
    }
}
