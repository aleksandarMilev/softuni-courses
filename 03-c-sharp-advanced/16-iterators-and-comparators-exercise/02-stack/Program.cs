namespace _03Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> customStack = new();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command
                    .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];

                switch (action)
                {
                    case "Push":
                        int[] items = arguments
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (int item in items)
                        {
                            customStack.Push(item);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            customStack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
