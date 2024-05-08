using TaskManagement.Core;
using TaskManagement.Core.Contracts;

namespace TaskManagement
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
