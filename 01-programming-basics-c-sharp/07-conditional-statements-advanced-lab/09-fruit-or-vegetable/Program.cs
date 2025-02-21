using System;
namespace _09FruitOrVegetable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            if (productType == "banana" || productType == "apple" || productType == "kiwi" || productType == "cherry" || productType == "lemon" || productType == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (productType == "tomato" || productType == "cucumber" || productType == "pepper" || productType == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}