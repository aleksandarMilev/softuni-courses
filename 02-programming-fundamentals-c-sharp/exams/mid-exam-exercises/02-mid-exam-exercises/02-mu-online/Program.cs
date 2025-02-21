using System;
namespace _02MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split("|");

            int health = 100;
            int bitcoins = 0;
            bool isOver = false;

            for (int i = 0; i < array.Length && isOver == false; i++)
            {
                string[] arguments = array[i].Split();
                switch (arguments[0])
                {
                    case "potion":
                        int healedPoints = int.Parse(arguments[1]);

                        if (health + healedPoints > 100)
                        {
                            healedPoints = 100 - health;
                        }

                        health += healedPoints;
                        Console.WriteLine($"You healed for {healedPoints} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        int bitcoinsFound = int.Parse(arguments[1]);
                        bitcoins += bitcoinsFound;
                        Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                        break;
                    default:
                        string monster = arguments[0];
                        int monsterDamage = int.Parse(arguments[1]);
                        health -= monsterDamage;

                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {monster}.");
                        }
                        else
                        {
                            isOver = true;
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            break;
                        }
                        break;
                }
            }

            if (isOver == false)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}