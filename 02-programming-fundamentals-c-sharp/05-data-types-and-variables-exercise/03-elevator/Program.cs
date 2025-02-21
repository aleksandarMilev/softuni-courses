using System;
namespace _03Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            
            double courses = Math.Ceiling((double)peopleCount  / elevatorCapacity);
            Console.WriteLine(courses);
        }
    }
}