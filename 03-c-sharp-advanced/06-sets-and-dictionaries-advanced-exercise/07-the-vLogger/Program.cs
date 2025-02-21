using System;
using System.Collections.Generic;
using System.Linq;
namespace _07TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[1];

                switch (action)
                {
                    case "joined":
                        string nameJoined = arguments[0];
                        if (!vloggers.ContainsKey(nameJoined))
                        {
                            vloggers.Add(nameJoined, new Vlogger(nameJoined));
                        }
                        break;
                    case "followed":
                        string follower = arguments[0];
                        string followed = arguments[2];

                        if (follower != followed &&
                            vloggers.ContainsKey(follower) &&
                            vloggers.ContainsKey(followed) &&
                            !vloggers[followed].Followers.Contains(follower) &&
                            !vloggers[follower].Following.Contains(followed))
                        {
                            vloggers[followed].Followers.Add(follower);
                            vloggers[follower].Following.Add(followed);
                        }
                        break;
                    default:
                        break;
                }
            }

            vloggers = vloggers
                .OrderByDescending(f => f.Value.Followers.Count)
                .ThenBy(f => f.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            var bestVlogger = vloggers.First();
            int i = 1;
            Console.WriteLine($"{i}. {bestVlogger.Key} : {bestVlogger.Value.Followers.Count} followers, {bestVlogger.Value.Following.Count} following");
            foreach (string follower in bestVlogger.Value.Followers.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogger in vloggers.Skip(1))
            {
                i++;
                Console.WriteLine($"{i}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }
        }
    }

    class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Followers = new();
            Following = new();
        }
        public string Name { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }
    }
}