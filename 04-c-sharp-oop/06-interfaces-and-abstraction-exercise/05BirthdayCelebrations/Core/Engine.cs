using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBirthable> birthables = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Citizen" || arguments[0] == "Pet")
                {
                    IBirthable birthable;

                    if (arguments.Length == 3)
                    {
                        birthable = new Pet(arguments[1], arguments[2]);
                    }
                    else
                    {
                        birthable = new Citizen(arguments[1], int.Parse(arguments[2]), arguments[3], arguments[4]);
                    }

                    birthables.Add(birthable);
                }

            }

            string year = Console.ReadLine();

            foreach (IBirthable birthable in birthables)
            {
                if (birthable.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(birthable.BirthDate);
                }
            }
        }
    }
}
