namespace _10ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> predicates = new();

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] arguments = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                string filter = arguments[1];
                string value = arguments[2];

                if (action == "Add filter")
                {
                    predicates.Add(filter + value, GetPredicate(filter, value)); 
                }
                else
                {
                    predicates.Remove(filter + value);
                }
            }

            foreach (var predicate in predicates)
            {
                names.RemoveAll(predicate.Value);
            }

            Console.WriteLine(string.Join(" ", names));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return n => n.StartsWith(value);
                case "Ends with":
                    return n => n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                case "Contains":
                    return n => n.Contains(value);
                default:
                    return default;
            }
        }
    }
}