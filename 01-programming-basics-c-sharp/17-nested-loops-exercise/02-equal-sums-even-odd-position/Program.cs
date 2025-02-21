using System;
namespace _02EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int oddPlacesSum = 0;
                int evenPlacesSum = 0;
                int currentNumber = i;
                bool isOddPlace = true;

                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    currentNumber /= 10;
                    if (isOddPlace)
                    {
                        oddPlacesSum += lastDigit;
                        isOddPlace = false;
                    }
                    else
                    {
                        evenPlacesSum += lastDigit;
                        isOddPlace = true;
                    }
                }
                if (oddPlacesSum == evenPlacesSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}