using System;
namespace _14PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (char char1 = 'a'; char1 < 'a' + l; char1++)
                    {
                        for (char char2 = 'a'; char2 < 'a' + l; char2++)
                        {
                            for (int k = 1; k <= n; k++)
                            {
                                if (k > i && k > j)
                                {
                                    Console.Write($"{i}{j}{char1}{char2}{k} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}