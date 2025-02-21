using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<Citizen> citizens = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] personInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Citizen citizen = new(name, country, age);
                citizens.Add(citizen);
            }

            foreach (Citizen citizen in citizens)
            {
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
