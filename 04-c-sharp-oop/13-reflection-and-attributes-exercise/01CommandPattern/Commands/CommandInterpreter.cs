using CommandPattern.Commands.Interfaces;
using System;
using System.Linq;
using System.Reflection;
namespace CommandPattern.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not fount!");
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

            return commandInstance.Execute(commandArguments);
        }
    }
}
