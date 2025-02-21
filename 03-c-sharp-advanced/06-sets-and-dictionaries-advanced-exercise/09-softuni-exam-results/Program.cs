using System;
using System.Collections.Generic;
using System.Linq;
namespace _09SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new();
            Dictionary<string, int> languagesSubmissions = new();
            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] arguments = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = arguments[0];
                string language = arguments[1];
                if (language == "banned")
                {
                    users.Remove(username);
                    continue;
                }

                int points = int.Parse(arguments[2]);

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;

                if (!users.ContainsKey(username))
                {
                    users.Add(username, 0);
                }

                if (users[username] < points)
                {
                    users[username] = points;
                }
            }

            users = users
                .OrderByDescending(x => x.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in languagesSubmissions.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}