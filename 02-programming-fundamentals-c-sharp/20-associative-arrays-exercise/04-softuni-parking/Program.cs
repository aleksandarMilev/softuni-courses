using System;
using System.Collections.Generic;
using System.Linq;
namespace _04SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string action = input[0];
                string username = input[1];
                switch (action)
                {
                    case "register":
                        string license = input[2];
                        if (users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                        }
                        else
                        {
                            users.Add(username, license);
                            Console.WriteLine($"{username} registered {license} successfully");
                        }
                        break;
                    case "unregister":
                        if (!users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            users.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                    default:
                        break;

                }
            }

            foreach (KeyValuePair<string, string> kvp in users)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}