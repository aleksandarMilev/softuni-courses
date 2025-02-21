using System;
namespace _01ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSpecial = false;
            double price = 0;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "special")
                {
                    isSpecial = true;
                    break;
                }

                if (command == "regular")
                {
                    break;
                }

                double priceInput = double.Parse(command);

                if (priceInput < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                price += priceInput;
            }

            if (price == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = price * 0.2;
            double totalPrice = price + taxes;

            if (isSpecial)
            {
                totalPrice *= 0.9;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {price:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}