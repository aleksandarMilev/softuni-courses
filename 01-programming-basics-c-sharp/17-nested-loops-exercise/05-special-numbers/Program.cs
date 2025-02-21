using System;
namespace _05SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1_111; i <= 9_999; i++)
            {
                bool isSpecial = true;
                int currentNum = i;
                while (currentNum > 0)
                {
                    int lastDigit = currentNum % 10;
                    currentNum /= 10;
                    if (lastDigit == 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    if (n % lastDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }
                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}