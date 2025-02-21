using System;
using System.Linq;
namespace _01EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());
            string[] names = new string[namesCount];

            for (int i = 0; i < namesCount; i++)
            {
                names[i] = Console.ReadLine();
            }

            int[] sortedNamesSums = new int[namesCount];

            for (int i = 0; i < sortedNamesSums.Length; i++)
            {
                sortedNamesSums[i] = GetNameSum(names[i]);
            }

            sortedNamesSums = sortedNamesSums.OrderBy(sum => sum).ToArray();

            for (int i = 0; i < sortedNamesSums.Length; i++)
            {
                Console.WriteLine(sortedNamesSums[i]);
            }
        }

        static int GetNameSum(string name)
        {
            int sum = 0;
            foreach (char letter in name)
            {
                if (isVowel(letter))
                {
                    sum += letter * name.Length;
                }
                else
                {
                    sum += letter / name.Length;
                }
            }
            return sum;
        }

        static bool isVowel(char letter)
        {
            char[] vowelLetters = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return vowelLetters.Contains(letter);
        }
    }
}