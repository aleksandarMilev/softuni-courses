using System;
using System.Collections.Generic;
namespace _07ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool listChanged = false;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();

                switch (arguments[0])
                {
                    case "Add":
                        listChanged = true;
                        int numberToTheEnd = int.Parse(arguments[1]);
                        AddNumberToTheEnd(numbers, numberToTheEnd);
                        break;
                    case "Remove":
                        listChanged = true;
                        int numberRemove = int.Parse(arguments[1]);
                        RemoveNumber(numbers, numberRemove);
                        break;
                    case "RemoveAt":
                        listChanged = true;
                        int indexRemove = int.Parse(arguments[1]);
                        RemoveIndex(numbers, indexRemove);
                        break;
                    case "Insert":
                        listChanged = true;
                        int numberInsert = int.Parse(arguments[1]);
                        int indexInsert = int.Parse(arguments[2]);
                        InsertNumberAtIndex(numbers, numberInsert, indexInsert);
                        break;
                    case "Contains":
                        int numberContains = int.Parse(arguments[1]);
                        NumberCointainsCheck(numbers, numberContains);
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        int sum = 0;
                        PrintSum(numbers, sum);
                        break;
                    case "Filter":
                        string condition = arguments[1];
                        int numberCondition = int.Parse(arguments[2]);
                        PrintNumbersFromCondition(numbers, condition, numberCondition);
                        break;
                }
            }

            if (listChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
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

        static void NumberCointainsCheck(List<int> numbers, int numberContains)
        {
            numbers.Contains(numberContains);
            if (numbers.Contains(numberContains) == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEven(List<int> numbers)
        {
            List<int> evenList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenList.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenList));
        }

        static void PrintOdd(List<int> numbers)
        {
            List<int> oddList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    oddList.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddList));
        }

        static void PrintSum(List<int> numbers, int sum)
        {
            sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }

        static void PrintNumbersFromCondition(List<int> numbers, string condition, int numberCondition)
        {
            List<int> conditionList = new List<int>();
            switch (condition)
            {
                case "<":
                    PrintSmaller(numbers, numberCondition, conditionList);
                    break;
                case ">":
                    PrintBigger(numbers, numberCondition, conditionList);
                    break;
                case ">=":
                    PrintBiggerOrEqual(numbers, numberCondition, conditionList);
                    break;
                case "<=":
                    PrintSmallerOrEqual(numbers, numberCondition, conditionList);
                    break;
            }
            Console.WriteLine(string.Join(" ", conditionList));
        }


        static void PrintSmallerOrEqual(List<int> numbers, int numberCondition, List<int> conditionList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= numberCondition)
                {
                    conditionList.Add(numbers[i]);
                }
            }
        }


        static void PrintBiggerOrEqual(List<int> numbers, int numberCondition, List<int> conditionList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= numberCondition)
                {
                    conditionList.Add(numbers[i]);
                }
            }
        }


        static void PrintBigger(List<int> numbers, int numberCondition, List<int> conditionList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numberCondition)
                {
                    conditionList.Add(numbers[i]);
                }
            }
        }


        static void PrintSmaller(List<int> numbers, int numberCondition, List<int> conditionList)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < numberCondition)
                {
                    conditionList.Add(numbers[i]);
                }
            }
        }

    }
}