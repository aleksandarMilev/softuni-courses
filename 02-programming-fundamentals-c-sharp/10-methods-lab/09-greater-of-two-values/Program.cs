using System;
namespace _09GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string result = GetMaxValue(a, b);
                Console.WriteLine(result);
            }
            else if (valueType == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int result = GetMaxValue(a, b);
                Console.WriteLine(result);
            }
            else if (valueType == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                char result = GetMaxValue(a, b);
                Console.WriteLine(result);
            }
        }

        static string GetMaxValue(string a, string b)
        {
            int result = string.Compare(a, b);
            if (result > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static int GetMaxValue(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static char GetMaxValue(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}