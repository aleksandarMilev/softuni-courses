using System;
using System.Collections.Generic;
using System.Linq;
namespace _01Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            Dictionary<string, Person> dict2 = new Dictionary<string, Person>();

            string command1;
            while ((command1 = Console.ReadLine()) != "end of contests")
            {
                string[] arr = command1.Split(":");
                string contest = arr[0];
                string password = arr[1];

                dict1.Add(password, contest);
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "end of submissions")
            {
                string[] arr2 = command2.Split("=>");
                string contest = arr2[0];
                string password = arr2[1];
                string username = arr2[2];
                int points = int.Parse(arr2[3]);

                if (!dict1.ContainsValue(contest) ||
                    !dict1.ContainsKey(password) ||
                    dict1[password] != contest)
                {
                    continue;
                }

                if (!dict2.ContainsKey(username))
                {
                    dict2[username] = new Person(username);
                    dict2[username].Contests.Add(contest, points);
                    dict2[username].TotalPoints += points;
                }

                if (dict2.ContainsKey(username))
                {
                    if (dict2[username].Contests.ContainsKey(contest))
                    {
                        if (dict2[username].Contests[contest] < points)
                        {
                            int diff = points - dict2[username].Contests[contest];
                            dict2[username].Contests[contest] = points;
                            dict2[username].TotalPoints += diff;
                        }
                    }
                    else
                    {
                        dict2[username].Contests.Add(contest, points);
                        dict2[username].TotalPoints += points;
                        
                    }
                }
            }

            var bestSt = dict2.
                OrderByDescending(x => x.Value.TotalPoints)
                .First();
            Console.WriteLine($"Best candidate is {bestSt.Value.Name} with total {bestSt.Value.TotalPoints} points.");

            Console.WriteLine("Ranking: ");
            foreach (var user in dict2.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.Contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    class Person
    {
        public Person(string name)
        {
            Name = name;
            TotalPoints = 0;
            Contests = new Dictionary<string, int>();
        }
        public string Name { get; set; }

        public int TotalPoints { get; set; }

        public Dictionary<string, int> Contests { get; set; }
    }
}
