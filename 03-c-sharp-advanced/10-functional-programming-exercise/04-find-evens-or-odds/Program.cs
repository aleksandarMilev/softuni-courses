namespace _04FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            string command = Console.ReadLine();

            Func<int[], List<int>> getNumbers = arr =>
            {
                List<int> list = new();
                for (int i = arr[0]; i <= arr[1]; i++)
                {
                    list.Add(i);
                }

                return list;
            };

            Func<string, int, bool> evenOrOdd = (str, number) =>
            {
                switch (str)
                {
                    case "even":
                        return number % 2 == 0;
                    case "odd":
                        return number % 2 != 0;
                    default: 
                        return default;
                }
            };

            foreach (int number in getNumbers(ranges))
            {
                if (evenOrOdd(command, number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}