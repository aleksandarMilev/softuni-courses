using System;
namespace _01GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double pigWeight = double.Parse(Console.ReadLine());

            bool isEnough = true;

            for (int i = 1; i <= 30; i++)
            {
                food -= 0.3;

                if (i % 2 == 0)
                {
                    hay -= 0.05 * food;
                }

                if (i % 3 == 0)
                {
                    cover -= pigWeight / 3;
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    isEnough = false;
                }
            }
            if (isEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}