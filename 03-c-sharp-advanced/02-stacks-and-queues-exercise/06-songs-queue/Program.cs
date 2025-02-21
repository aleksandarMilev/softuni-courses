namespace _06SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                switch (action)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string songAdd = string.Join(" ", command.Skip(1));

                        if (!songs.Contains(songAdd))
                        {
                            songs.Enqueue(songAdd);
                        }
                        else
                        {
                            Console.WriteLine($"{songAdd} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}