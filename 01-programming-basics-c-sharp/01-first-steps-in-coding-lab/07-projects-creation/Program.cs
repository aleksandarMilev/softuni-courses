using System;
namespace _07ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            int hours = num * 3;
            Console.WriteLine($"The architect {name} will need {hours} hours to complete {num} project/s.");
        }
    }
}