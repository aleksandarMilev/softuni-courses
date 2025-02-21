namespace _09PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string criteria = arguments[1];
                string value = arguments[2];

                if (action == "Remove")
                {
                    names.RemoveAll(GetPredicate(criteria, value));
                }
                else
                {
                    List<string> doubleNames = names.FindAll(GetPredicate(criteria, value));
                    foreach (string name in doubleNames)
                    {
                        names.Insert(names.IndexOf(name), name);
                    }
                }
            }`

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string criteria, string value)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return n => n.StartsWith(value);
                case "EndsWith":
                    return n => n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                default:
                    return default;
            }
        }
    }
}