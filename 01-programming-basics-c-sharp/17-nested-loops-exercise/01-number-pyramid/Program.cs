using System;
namespace _01NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numbersToPrintForRow = 1;
            for (int i = 0; i < n;)
            {
                for (int k = 0; k < numbersToPrintForRow; k++)
                {
                    i++;
                    Console.Write(i + " ");

                    if (i == n)
                    {
                        break;
                    }
                }
                Console.WriteLine();
                numbersToPrintForRow++;
            }
        }
    }
}