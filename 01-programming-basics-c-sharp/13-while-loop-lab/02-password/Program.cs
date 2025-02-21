using System;
namespace _02Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (num > sum)
            {
                int enteredNum = int.Parse(Console.ReadLine());
                sum += enteredNum;
            }
            Console.WriteLine(sum);
        }
    }
}