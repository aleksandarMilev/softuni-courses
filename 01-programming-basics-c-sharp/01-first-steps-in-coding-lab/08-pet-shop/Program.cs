using System;
namespace _08PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPackDog = int.Parse(Console.ReadLine());
            int numPackCat = int.Parse(Console.ReadLine());
            double totalSum = numPackDog * 2.5 + numPackCat * 4;
            Console.Write(totalSum);
            Console.WriteLine(" lv.");
        }
    }
}