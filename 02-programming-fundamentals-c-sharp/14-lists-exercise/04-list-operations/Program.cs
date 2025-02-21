using System;
using System.Collections.Generic;
namespace _04ListOperations
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
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Add":
                        int numberAdd = int.Parse(arguments[1]);
                        numbers.Add(numberAdd);
                        break;
                    case "Insert":
                        int numberInsert = int.Parse(arguments[1]);
                        int indexInsert = int.Parse(arguments[2]);
                        if (!IsValidIndex(numbers, indexInsert))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(indexInsert, numberInsert);
                        break;
                    case "Remove":
                        int indexRemove = int.Parse(arguments[1]);
                        if (!IsValidIndex(numbers, indexRemove))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.RemoveAt(indexRemove);
                        break;
                    case "Shift":
                        int count = int.Parse(arguments[2]) % numbers.Count;
                        if (arguments[1] == "left")
                        {
                            List<int> shiftList = numbers.GetRange(0, count);
                            numbers.RemoveRange(0, count);
                            numbers.InsertRange(numbers.Count, shiftList);
                            break;
                        }
                        else if (arguments[1] == "right")
                        {
                            List<int> shiftList = numbers.GetRange(numbers.Count - count, count);
                            numbers.RemoveRange(numbers.Count - count, count);
                            numbers.InsertRange(0, shiftList);
                            break;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool IsValidIndex(List<int> numbers, int index)
        {
            return index >= 0 && index <= numbers.Count - 1;
        }
    }
}