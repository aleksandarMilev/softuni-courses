using System;
namespace _01ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string input = Console.ReadLine();

                int nameStartIndex = input.IndexOf('@');
                int nameEndIndex = input.IndexOf('|');
                string name = input.Substring(nameStartIndex + 1, nameEndIndex - nameStartIndex - 1);

                int ageStartIndex = input.IndexOf('#');
                int ageEndIndex = input.IndexOf('*');
                string age = input.Substring(ageStartIndex + 1, ageEndIndex - ageStartIndex - 1);
                
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}