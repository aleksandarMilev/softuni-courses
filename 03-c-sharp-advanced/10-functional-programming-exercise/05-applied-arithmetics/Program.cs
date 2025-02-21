namespace _05AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> printList = list =>
            {
                Console.WriteLine(string.Join(" ", list));
            };

            Func<string, List<int>, List<int>> operations = (command, list) =>
            {
                List<int> result = new();
                foreach (int number in list)
                {
                    switch (command)
                    {
                        case "add":
                            result.Add(number + 1);
                            break;
                        case "multiply":
                            result.Add(number * 2);
                            break;
                        case "subtract":
                            result.Add(number - 1);
                            break; 
                        default:
                            break;
                    }
                }

                return result;
            };

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => int.Parse(str))
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "printList")
                {
                    printList(numbers);
                }
                else
                {
                    numbers = operations(command, numbers);
                }
            }
        }
    }
}