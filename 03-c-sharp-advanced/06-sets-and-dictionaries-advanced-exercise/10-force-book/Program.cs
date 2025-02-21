namespace _10ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> users = new();

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] arguments;
                string side;
                string user;

                if (command.Contains("|"))
                {
                    arguments = command
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    side = arguments[0];
                    user = arguments[1];

                    if (!users.Values.Any(u => u.Contains(user)))
                    {
                        if (!users.ContainsKey(side))
                        {
                            users.Add(side, new());
                        }

                        users[side].Add(user);
                    }
                }
                else
                {
                    arguments = command
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    user = arguments[0];
                    side = arguments[1];

                    foreach (var sideUsers in users)
                    {
                        if (sideUsers.Value.Contains(user))
                        {
                            sideUsers.Value.Remove(user);
                            break;
                        }
                    }

                    if (!users.ContainsKey(side))
                    {
                        users.Add(side, new());
                    }

                    users[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedSidesUsers = users
                .OrderByDescending(u => u.Value.Count)
                .ToDictionary(u => u.Key, u => u.Value);

            foreach (var sideUsers in orderedSidesUsers)
            {
                if (sideUsers.Value.Any())
                {
                    Console.WriteLine($"Side: {sideUsers.Key}, Members: {sideUsers.Value.Count}");
                    foreach (var user in sideUsers.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}