using System;
namespace _03._Lucky_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int num = 1111; num <= 9999; num++)
            {
                int digit1 = num / 1000;
                int digit2 = (num / 100) % 10;
                int digit3 = (num / 10) % 10;
                int digit4 = num % 10;

                if (digit1 + digit2 == digit3 + digit4 &&
                    N % (digit1 + digit2) == 0 &&
                    digit1 >= 1 && digit1 <= 9 &&
                    digit2 >= 1 && digit2 <= 9 &&
                    digit3 >= 1 && digit3 <= 9 &&
                    digit4 >= 1 && digit4 <= 9)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}