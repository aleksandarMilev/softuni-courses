using System;
namespace _04SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNUmbr = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int result;
            int counter = 0;
            bool isValid = false;

            for (int x = firstNUmbr; x <= secondNumber; x++)
            {
                for (int y = firstNUmbr; y <= secondNumber; y++)
                {
                    counter++;
                    result = x + y;
                    if (result == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({x} + {y} = {magicNumber})");
                        isValid = true;
                        break;
                    }
                }
                if (isValid)
                {
                    break;
                }
            }
            if (!isValid)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}