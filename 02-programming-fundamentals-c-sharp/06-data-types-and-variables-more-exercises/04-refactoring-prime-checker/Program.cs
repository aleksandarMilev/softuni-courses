using System;
namespace _04RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRangeToCheck = int.Parse(Console.ReadLine());
            for (int i = 2; i <= endOfRangeToCheck; i++)
            {
                int numberChecked = i;
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (numberChecked % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{numberChecked} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}