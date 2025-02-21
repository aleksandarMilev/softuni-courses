using System;
namespace _03HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                string currentName = arguments[0];
                if (arguments[2] != "not")
                {
                    if (!names.Contains(currentName))
                    {
                        names.Add(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"{currentName} is already in the list!");
                    }
                }
                else
                {
                    if (names.Contains(currentName))
                    {
                        names.Remove(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"{currentName} is not in the list!");
                    }
                }
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}