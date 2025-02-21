using CommandPattern.Commands;
using CommandPattern.Commands.Interfaces;
using CommandPattern.Core;
using CommandPattern.Core.Interfaces;
namespace CommandPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
