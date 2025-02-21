using System;
using System.Collections.Generic;
using People.Models;

namespace People
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new();

            for (int i = 0; i < lines; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = arguments[0];
                string lastName = arguments[1];
                int age = int.Parse(arguments[2]);
                decimal salary = decimal.Parse(arguments[3]);

                try
                {
                    Person person = new(firstName, lastName, age, salary);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
