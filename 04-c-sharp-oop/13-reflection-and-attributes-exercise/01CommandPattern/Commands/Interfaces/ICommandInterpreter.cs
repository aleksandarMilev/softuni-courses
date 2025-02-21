namespace CommandPattern.Commands.Interfaces
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
