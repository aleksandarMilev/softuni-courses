namespace _02StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new(numbersInput);

            string input;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] command = input
                    .ToLower()
                    .Split();

                switch (command[0])
                {
                    case "add":
                        int[] numbersAdd = command
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (int number in numbersAdd)
                        {
                            stack.Push(number);
                        }

                        break;
                    case "remove":
                        int countToRemove = int.Parse(command[1]);

                        if (countToRemove > stack.Count)
                        {
                            break;
                        }

                        while (countToRemove > 0)
                        {
                            stack.Pop();
                            countToRemove--;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}