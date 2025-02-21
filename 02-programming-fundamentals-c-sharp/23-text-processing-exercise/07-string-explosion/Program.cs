using System;
using System.Text;
namespace _07StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = ProcessExplosion(input);
            Console.WriteLine(result);
        }

        static string ProcessExplosion(string input)
        {
            StringBuilder sb = new StringBuilder();
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    sb.Append(input[i]);
                }
                else if (strength == 0)
                {
                    sb.Append(input[i]);
                }
                else
                {
                    strength--;
                }
            }

            return sb.ToString();
        }
    }
}