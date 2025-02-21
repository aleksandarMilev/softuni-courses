using CommandPattern.Commands.Interfaces;
using System;
namespace CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        private const int DefaultExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefaultExitCode);
            return null;
        }
    }
}
