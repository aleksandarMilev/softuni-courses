using System;
namespace _01IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int firstPlusSecondNum = firstNumber + secondNumber;
            int division = firstPlusSecondNum / thirdNumber;
            int result = division * fourthNumber;
            Console.WriteLine(result);
        }
    }
}