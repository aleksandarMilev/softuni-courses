using System;
using System.Collections.Generic;
namespace _08SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipList = new();
            HashSet<string> regularList = new();

            string reservations;
            while ((reservations = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(reservations[0]))
                {
                    vipList.Add(reservations);
                    continue;
                }

                regularList.Add(reservations);
            }

            string guest;
            while ((guest = Console.ReadLine()) != "END")
            {
                if (vipList.Contains(guest))
                {
                    vipList.Remove(guest);
                    continue;
                }

                regularList.Remove(guest);
            }

            Console.WriteLine(vipList.Count + regularList.Count);

            foreach (string name in vipList)
            {
                Console.WriteLine(name);
            }

            foreach (string name in regularList)
            {
                Console.WriteLine(name);
            }
        }
    }
}