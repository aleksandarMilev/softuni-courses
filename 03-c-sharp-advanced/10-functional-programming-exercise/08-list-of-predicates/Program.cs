namespace _08ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int endOfRange = int.Parse(Console.ReadLine());
            HashSet<int> divisors = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => int.Parse(str))
                .ToHashSet();

            List<Predicate<int>> predicates = new();
            foreach (int divisor in divisors)
            {
                predicates.Add(n => n % divisor == 0);
            }

            Func<int, List<int>> getRange = n =>
            {
                List<int> result = new();
                for (int i = 1; i <= n; i++)
                {
                    result.Add(i);
                }

                return result;
            };
            List<int> numbers = getRange(endOfRange);

            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (Predicate<int> predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}