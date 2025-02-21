using System;
namespace _07._Football_League
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int totalFans = int.Parse(Console.ReadLine());
            int sectorA = 0; int sectorB = 0; int sectorV = 0; int sectorG = 0;
            

            for (int i = 1; i <= totalFans; i++)
            {
                string sector = Console.ReadLine();
                if (sector == "A")
                {
                    sectorA++;
                }
                else if (sector == "B")
                {
                    sectorB++;
                }
                else if (sector == "V")
                {
                    sectorV++;
                }
                else if (sector == "G")
                {
                    sectorG++;
                }
            }
            double sectorAP = (double)sectorA / totalFans * 100;
            Console.WriteLine($"{sectorAP:f2}%");
            double sectorBP = (double)sectorB / totalFans * 100;
            Console.WriteLine($"{sectorBP:f2}%");
            double sectorVP = (double)sectorV / totalFans * 100;
            Console.WriteLine($"{sectorVP:f2}%");
            double sectorGP = (double)sectorG / totalFans * 100;
            Console.WriteLine($"{sectorGP:f2}%");
            double total = (double)totalFans / stadiumCapacity * 100;
            Console.WriteLine($"{total:f2}%");
        }
    }
}