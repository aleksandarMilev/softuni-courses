using CommandPattern.Commands.Interfaces;
namespace CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello {args[0]}";
    }
}
