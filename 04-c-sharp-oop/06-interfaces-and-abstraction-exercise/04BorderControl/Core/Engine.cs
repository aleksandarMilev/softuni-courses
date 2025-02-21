using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IIdentifiable> identifiables = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable identifiable;

                if (arguments.Length == 3)
                {
                    identifiable = new Citizen(arguments[0], int.Parse(arguments[1]), arguments[2]);
                }
                else
                {
                    identifiable = new Robot(arguments[0], arguments[1]);
                }

                identifiables.Add(identifiable);
            }

            string fakeIDsLastThreeDigits = Console.ReadLine();

            foreach (IIdentifiable identifiable in identifiables)
            {
                if (identifiable.ID.EndsWith(fakeIDsLastThreeDigits))
                {
                    Console.WriteLine(identifiable.ID);
                }
            }
        }
    }
}
