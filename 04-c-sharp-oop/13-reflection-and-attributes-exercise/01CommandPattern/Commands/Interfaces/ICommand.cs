namespace CommandPattern.Commands.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
