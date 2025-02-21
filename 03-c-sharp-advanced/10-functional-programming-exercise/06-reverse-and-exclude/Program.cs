namespace _06ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, Predicate<int>, List<int>> filter = (list, match) =>
            {
                List<int> result = new();
                foreach (int number in list)
                {
                    if (!match(number))
                    {
                        result.Add(number);
                    }
                }

                return result;
            };

            Func<List<int>, List<int>> reverse = list =>
            {
                List<int> result = new();
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    result.Add(list[i]);
                }

                return result;
            };

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => int.Parse(str))
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers = filter(numbers, n => n % divisor == 0);
            numbers = reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}