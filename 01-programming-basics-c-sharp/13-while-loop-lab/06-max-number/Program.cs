using System;
namespace _06MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.MinValue;
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                int numInput = int.Parse(command);
                if (numInput > maxNum)
                {
                    maxNum = numInput;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}