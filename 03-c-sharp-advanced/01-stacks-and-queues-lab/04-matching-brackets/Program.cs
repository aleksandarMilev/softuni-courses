using System;
namespace _04MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexesOfBrackets = new();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexesOfBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int lastOpenBracketInd = indexesOfBrackets.Pop();
                    for (int k = lastOpenBracketInd; k <= i; k++)
                    {
                        Console.Write(input[k]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}