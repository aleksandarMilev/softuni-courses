using System;
namespace _03SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nonPrimeSum = 0;
            int primeSum = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
                    Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
                    break;
                }
                int num = int.Parse(command);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeSum += num;
                }
                else
                {
                    nonPrimeSum += num;
                }
            }
        }
    }
}