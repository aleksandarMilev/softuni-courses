using System;
namespace PlayCatch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int exceptionsCount = 3;
            while (exceptionsCount > 0)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];

                try
                {
                    int index = int.Parse(arguments[1]);
                    switch (action)
                    {
                        case "Replace":
                            string element = arguments[2];
                            numbers[index] = element;
                            break;
                        case "Print":
                            int endIndex = int.Parse(arguments[2]);
                            string result = "";

                            for (int i = index; i <= endIndex; i++)
                            {
                                result += $"{numbers[i]}, ";
                            }

                            Console.WriteLine(result.TrimEnd(' ', ','));
                            break;
                        case "Show":
                            Console.WriteLine(numbers[index]);
                            break;
                        default:
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount--;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}