using System;

namespace _07CustomComparator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<int, int, int> compare = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            int[] numbersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbersInput, (x, y) => compare(x, y));
            Console.WriteLine(string.Join(" ", numbersInput));
        }
    }
}
