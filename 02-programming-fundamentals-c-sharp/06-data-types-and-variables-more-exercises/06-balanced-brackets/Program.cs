using System;
namespace _06BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openBracketsCount = 0;
            bool isBalanced = true;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                foreach (char character in line)
                {
                    if (character == '(')
                    {
                        openBracketsCount++;
                    }
                    else if (character == ')')
                    {
                        openBracketsCount--;
                        if (openBracketsCount < 0)
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }
            if (openBracketsCount != 0 || !isBalanced)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}