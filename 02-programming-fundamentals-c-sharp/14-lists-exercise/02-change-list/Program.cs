using System;
using System.Collections.Generic;
namespace _02ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Delete":
                        int numberDelete = int.Parse(arguments[1]);
                        DeleteNumber(integers, numberDelete);
                        break;
                    case "Insert":
                        int elementInsert = int.Parse(arguments[1]);
                        int positionInsert = int.Parse(arguments[2]);
                        InsertElement(integers, elementInsert, positionInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", integers));
        }
        static void DeleteNumber(List<int> integers, int numberDelete)
        {
            integers.RemoveAll(item => item == numberDelete);
        }

        static void InsertElement(List<int> integers, int elementInsert, int positionInsert)
        {
            integers.Insert(positionInsert, elementInsert);
        }

    }
}