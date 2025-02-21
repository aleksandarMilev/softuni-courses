namespace _03MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            Stack<int> numbers = new();

            for (int i = 0; i < inputsCount; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        int elementPush = command[1];
                        numbers.Push(elementPush);
                        break;
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                    default:
                        break;
                } 
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}