using System;

namespace TwoPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int firstPairSum = 0;
            int secondPairSum = 0;
            int maxDifference = 0;
            bool allPairsEqual = true;

            for (int i = 0; i < n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                int currentSum = num1 + num2;

                if (i % 2 == 0)
                {
                    firstPairSum = currentSum;
                }
                else
                {
                    secondPairSum = currentSum;

                    if (firstPairSum != secondPairSum)
                    {
                        allPairsEqual = false;
                        int difference = Math.Abs(firstPairSum - secondPairSum);
                        if (difference > maxDifference)
                        {
                            maxDifference = difference;
                        }
                    }
                }
            }

            if (allPairsEqual)
            {
                Console.WriteLine($"Yes, value={firstPairSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDifference}");
            }
        }
    }
}
