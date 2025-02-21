namespace _07PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>, Predicate<string>> printNames = (list, match) =>
            {
                foreach (string name in list)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            int correctLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            printNames(names, name => name.Length <= correctLength);
        }
    }
}