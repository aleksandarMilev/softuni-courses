using System;
namespace _05DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < linesCount; i++)
            {
                message += ((char)(char.Parse(Console.ReadLine()) + key)).ToString();
            }
            Console.WriteLine(message);
        }
    }
}