using System;
using System.Collections.Generic;
using System.Linq;
namespace JudgeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contest> contestsMap = new Dictionary<string, Contest>();

            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] input = command.Split(" -> ");
                string username = input[0];
                string contestName = input[1];
                int pointsInput = int.Parse(input[2]);

                if (!contestsMap.ContainsKey(contestName))
                {
                    contestsMap.Add(contestName, new Contest(contestName));
                    contestsMap[contestName].ContestMap.Add(username, new User(username));
                    contestsMap[contestName].ContestMap[username].UserMap.Add(username, pointsInput);
                }
                else
                {
                    if (!contestsMap[contestName].ContestMap.ContainsKey(username))
                    {
                        contestsMap[contestName].ContestMap.Add(username, new User(username));
                        contestsMap[contestName].ContestMap[username].UserMap.Add(username, pointsInput);
                    }
                    else
                    {
                        if (contestsMap[contestName].ContestMap[username].UserMap[username] < pointsInput)
                        {
                            contestsMap[contestName].ContestMap[username].UserMap[username] = pointsInput;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Contest> kvp in contestsMap)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.ContestMap.Count} participants");

                int counter = 1;
                var sortedParticipants = kvp.Value.ContestMap.Values
                    .OrderByDescending(user => user.UserMap.Values.Max())
                    .ThenBy(user => user.Username);

                foreach (var user in sortedParticipants)
                {
                    var sortedPoints = user.UserMap
                        .OrderByDescending(entry => entry.Value)
                        .ThenBy(entry => entry.Key);

                    foreach (var entry in sortedPoints)
                    {
                        Console.WriteLine($"{counter}. {entry.Key} <::> {entry.Value}");
                        counter++;
                    }
                }
            }

            Dictionary<string, int> userTotalPoints = new Dictionary<string, int>();
            foreach (KeyValuePair<string, Contest> kvp in contestsMap)
            {
                foreach (KeyValuePair<string, User> kvp2 in kvp.Value.ContestMap)
                {
                    string username = kvp2.Key;
                    int totalPoints = kvp2.Value.UserMap.Values.Sum();

                    if (userTotalPoints.ContainsKey(username))
                    {
                        userTotalPoints[username] += totalPoints;
                    }
                    else
                    {
                        userTotalPoints[username] = totalPoints;
                    }
                }
            }

            var sortedUsers = userTotalPoints.OrderByDescending(p => p.Value)
                .ThenBy(n => n.Key);
            Console.WriteLine("Individual standings:");
            int counter2 = 0;
            foreach (var item in sortedUsers)
            {
                counter2++;
                Console.WriteLine($"{counter2}. {item.Key} -> {item.Value}");
            }
        }
    }

    class Contest
    {
        public Contest(string contestName)
        {
            ContestName = contestName;
            ContestMap = new Dictionary<string, User>();
        }
        public string ContestName { get; set; }

        public Dictionary<string, User> ContestMap { get; set; }
    }

    class User
    {
        public User(string username)
        {
            Username = username;
            UserMap = new Dictionary<string, int>();
        }
        public string Username { get; set; }
        public Dictionary<string, int> UserMap { get; set; }
    }
}