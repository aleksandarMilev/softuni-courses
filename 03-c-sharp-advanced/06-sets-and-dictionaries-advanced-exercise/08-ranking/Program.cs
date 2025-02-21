using System;
using System.Collections.Generic;
using System.Linq;
namespace _08Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new();
            Dictionary<string, User> users = new();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] arguments1 = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = arguments1[0];
                string password = arguments1[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(password, contest);
                }
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "end of submissions")
            {
                string[] arguments2 = command2.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest2 = arguments2[0];
                string password2 = arguments2[1];
                string username = arguments2[2];
                int points = int.Parse(arguments2[3]);

                if (!contests.ContainsKey(password2))
                {
                    continue;
                }

                if (contests[password2] != contest2)
                {
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users[username] = new User(username);
                    users[username].ContestsMap.Add(contest2, points);
                    users[username].TotalPoints += points;
                }

                if (users[username].ContestsMap.ContainsKey(contest2))
                {
                    if (users[username].ContestsMap[contest2] < points)
                    {
                        int diff = points - users[username].ContestsMap[contest2];
                        users[username].ContestsMap[contest2] = points;
                        users[username].TotalPoints += diff;
                    }
                }
                else
                {
                    users[username].ContestsMap.Add(contest2, points);
                    users[username].TotalPoints += points;
                }
            }

            users = users.OrderByDescending(x => x.Value.TotalPoints)
                .ToDictionary(x => x.Key, x => x.Value);

            var bestStudent = users.First();
            Console.WriteLine($"Best candidate is {bestStudent.Key} with total {bestStudent.Value.TotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.Value.ContestsMap.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    class User
    {
        public User(string name)
        {
            Name = name;
            ContestsMap = new();
            TotalPoints = 0;
        }
        public string Name { get; set; }

        public Dictionary<string, int> ContestsMap { get; set; }

        public int TotalPoints { get; set; }
    }
}