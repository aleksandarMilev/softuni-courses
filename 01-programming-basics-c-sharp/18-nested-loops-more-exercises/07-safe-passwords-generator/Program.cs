using System;
namespace _07SafePasswordsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 35; i <= 55;)
            {
                for (int j = 64; j <= 96;)
                {
                    for (int k = 1; k <= a; k++)
                    {
                        for (int l = 1; l <= b; l++)
                        {
                            char firstChar = ((char)i);
                            char secondChar = ((char)j);
                            Console.Write($"{firstChar}{secondChar}{k}{l}{secondChar}{firstChar}|");
                            counter++;
                            i++;
                            j++;
                            if (counter >= max || (k == a && l == b))
                            {
                                return;
                            }
                            if (i > 55)
                            {
                                i = 35;
                            }
                            if (j > 96)
                            {
                                j = 64;
                            }
                        }
                    }
                }
            }
        }
    }
}

