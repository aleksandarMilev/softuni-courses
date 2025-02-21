namespace _03CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<HashSet<int>, int> getMinNumber = set =>
            {
                int min = int.MaxValue;
                foreach (int number in set)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };

            HashSet<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToHashSet();

            Console.WriteLine(getMinNumber(numbers));
        }
    }
}