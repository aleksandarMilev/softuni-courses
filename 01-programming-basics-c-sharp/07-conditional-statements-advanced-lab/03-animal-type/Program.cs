using System;
namespace _03AnimalType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string anmimal = Console.ReadLine();
            switch (anmimal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}