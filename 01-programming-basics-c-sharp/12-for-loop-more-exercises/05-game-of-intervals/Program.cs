using System;
namespace _05._Game_Of_Intervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());
            int invalidCount = 0; int from0To9 = 0; int from10To19 = 0; int from20To29 = 0; int from30To39 = 0; int from40To50 = 0;
            double points = 0;
            for (int i = 1; i <= moves; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0 && num <= 9)
                {
                    from0To9++;
                    points += num * 0.2;
                }
                else if (num >= 10 && num <= 19)
                {
                    from10To19++;
                    points += num * 0.3;
                }
                else if (num >= 20 && num <= 29)
                {
                    from20To29++;
                    points += num * 0.4;
                }
                else if (num >= 30 && num <= 39)
                {
                    from30To39++;
                    points += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    from40To50++;
                    points += 100;
                }
                else if (num < 0 || num > 50)
                {
                    invalidCount++;
                    points /= 2;
                }
            }
            Console.WriteLine($"{points:f2}");
            double from0To9P = (double)from0To9 / moves * 100;
            Console.WriteLine($"From 0 to 9: {from0To9P:f2}%");
            double from10To19P = (double)from10To19 / moves * 100;
            Console.WriteLine($"From 10 to 19: {from10To19P:f2}%");
            double from20To29P = (double)from20To29 / moves * 100;
            Console.WriteLine($"From 20 to 29: {from20To29P:f2}%");
            double from30To39P = (double)from30To39 / moves * 100;
            Console.WriteLine($"From 30 to 39: {from30To39P:f2}%");
            double from40To50P = (double)from40To50 / moves * 100;
            Console.WriteLine($"From 40 to 50: {from40To50P:f2}%");
            double invelidCountP = (double)invalidCount / moves * 100;
            Console.WriteLine($"Invalid numbers: {invelidCountP:f2}%");
        }
    }
}