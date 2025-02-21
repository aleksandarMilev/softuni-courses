using System;
namespace _09._Weather_Forecast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = string.Empty;
            switch (input)
            {
                case "sunny": output = "It's warm outside!"; break;
                default: output = "It's cold outside!"; break;
            }
            Console.WriteLine(output);
        }
    }
}