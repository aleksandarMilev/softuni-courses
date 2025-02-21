using System;
using System.Collections.Generic;
namespace _03MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Shoot":
                        int indexShoot = int.Parse(arguments[1]);
                        int powerShoot = int.Parse(arguments[2]);
                        ShootTarget(targets, indexShoot, powerShoot);
                        break;
                    case "Add":
                        int indexAdd = int.Parse(arguments[1]);
                        int valueAdd = int.Parse(arguments[2]);
                        AddTarget(targets, indexAdd, valueAdd);
                        break;
                    case "Strike":
                        int indexStrike = int.Parse(arguments[1]);
                        int radiusStrike = int.Parse(arguments[2]);
                        StrikeRadius(targets, indexStrike, radiusStrike);
                        break;
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static void ShootTarget(List<int> targets, int indexShoot, int powerShoot)
        {
            if (IsIndexValid(targets, indexShoot))
            {
                targets[indexShoot] -= powerShoot;
                if (targets[indexShoot] <= 0)
                {
                    targets.Remove(targets[indexShoot]);
                }
            }
        }
        static void AddTarget(List<int> targets, int indexAdd, int valueAdd)
        {
            if (!IsIndexValid(targets, indexAdd))
            {
                Console.WriteLine("Invalid placement!");
            }
            else
            {
                targets.Insert(indexAdd, valueAdd);
            }
        }
        static void StrikeRadius(List<int> targets, int indexStrike, int radiusStrike)
        {
            int startIndex = indexStrike - radiusStrike;
            int endIndex = indexStrike + radiusStrike;

            if (startIndex >= 0 && endIndex < targets.Count)
            {
                targets.RemoveRange(startIndex, endIndex - startIndex + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
        static bool IsIndexValid(List<int> targets, int index)
        {
            return index >= 0 && index <= targets.Count - 1;
        }
    }
}