using System;
namespace _07MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNum = int.MaxValue;
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                int numInput = int.Parse(input);
                if (numInput < minNum)
                {
                    minNum = numInput;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}