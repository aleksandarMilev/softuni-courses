namespace _11TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberCheck = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> checkNameLength = (name, numberCheck) =>
            {
                int nameSum = name.Sum(c => c);
                return nameSum >= numberCheck;
            };

            Func<List<string>, int, Func<string, int, bool>, string> getFirstName = (names, numberCheck, match) =>
            {
                foreach (string name in names)
                {
                    if (match(name, numberCheck))
                    {
                        return name;
                    }
                }

                return null;
            };

            Console.WriteLine(getFirstName(names, numberCheck, checkNameLength));
        }
    }
}