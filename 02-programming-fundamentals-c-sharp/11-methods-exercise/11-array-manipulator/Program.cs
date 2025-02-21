using System;
namespace _11ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "exchange":
                        int index = int.Parse(arguments[1]);
                        numbers = SplitArray(numbers, index);
                        break;
                    case "max":
                        string maxType = arguments[1];
                        PrintMaxTypeIndex(numbers, maxType);
                        break;
                    case "min":
                        string minType = arguments[1];
                        PrintMinTypeIndex(numbers, minType);
                        break;
                    case "first":
                        int firstCount = int.Parse(arguments[1]);
                        string firstType = arguments[2];
                        PrintFirstTypeCount(numbers, firstCount, firstType);
                        break;
                    case "last":
                        int lastCount = int.Parse(arguments[1]);
                        string lastType = arguments[2];
                        PrintLastTypeCount(numbers, lastCount, lastType);
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static int[] SplitArray(int[] numbers, int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }

            int[] splitArr = new int[numbers.Length];
            int splitArrIndex = 0;

            for (int i = index + 1; i < numbers.Length; i++)
            {
                splitArr[splitArrIndex] = numbers[i];
                splitArrIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                splitArr[splitArrIndex] = numbers[i];
                splitArrIndex++;
            }

            return splitArr;
        }

        static void PrintMaxTypeIndex(int[] numbers, string maxType)
        {
            int maxNumber = int.MinValue;
            int maxIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (maxType == "odd" && numbers[i] % 2 != 0 ||
                    maxType == "even" && numbers[i] % 2 == 0)
                {
                    if (numbers[i] >= maxNumber)
                    {
                        maxNumber = numbers[i];
                        maxIndex = i;
                    }
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        static void PrintMinTypeIndex(int[] numbers, string minType)
        {
            int minNumber = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (minType == "odd" && numbers[i] % 2 != 0 ||
                    minType == "even" && numbers[i] % 2 == 0)
                {
                    if (numbers[i] <= minNumber)
                    {
                        minNumber = numbers[i];
                        minIndex = i;
                    }
                }
            }

            if (minIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        static void PrintFirstTypeCount(int[] numbers, int firstCount, string firstType)
        {
            if (firstCount > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string firstElements = "";
            int elementCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (firstType == "odd" && numbers[i] % 2 != 0 ||
                    firstType == "even" && numbers[i] % 2 == 0)
                {
                    firstElements += $"{numbers[i]}, ";
                    elementCount++;
                    if (elementCount >= firstCount)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
        }

        static void PrintLastTypeCount(int[] numbers, int lastCount, string lastType)
        {
            if (lastCount > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string lastElements = "";
            int elementCount = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (lastType == "odd" && numbers[i] % 2 != 0 ||
                    lastType == "even" && numbers[i] % 2 == 0)
                {
                    lastElements = $"{numbers[i]}, " + lastElements;
                    elementCount++;
                    if (elementCount >= lastCount)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
        }

    }
}