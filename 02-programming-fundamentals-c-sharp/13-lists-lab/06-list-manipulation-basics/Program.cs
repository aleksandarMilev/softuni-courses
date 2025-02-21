using System;
using System.Collections.Generic;
namespace _06ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();

                switch (arguments[0])
                {
                    case "Add":
                        int numberToTheEnd = int.Parse(arguments[1]);
                        AddNumberToTheEnd(numbers, numberToTheEnd);
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(arguments[1]);
                        RemoveNumber(numbers, numberRemove);
                        break;
                    case "RemoveAt":
                        int indexRemove = int.Parse(arguments[1]);
                        RemoveIndex(numbers, indexRemove);
                        break;
                    case "Insert":
                        int numberInsert = int.Parse(arguments[1]);
                        int indexInsert = int.Parse(arguments[2]);
                        InsertNumberAtIndex(numbers, numberInsert, indexInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void AddNumberToTheEnd(List<int> numbers, int numberToTheEnd)
        {
            numbers.Add(numberToTheEnd);
        }
        static void RemoveNumber(List<int> numbers, int numberRemove)
        {
            numbers.Remove(numberRemove);
        }
        static void RemoveIndex(List<int> numbers, int indexRemove)
        {
            numbers.RemoveAt(indexRemove);
        }
        static void InsertNumberAtIndex(List<int> numbers, int numberInsert, int indexInsert)
        {
            numbers.Insert(indexInsert, numberInsert);
        }
    }
}