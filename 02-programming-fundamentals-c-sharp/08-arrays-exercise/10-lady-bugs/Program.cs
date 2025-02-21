using System;
internal class Program
{
    static void Main()
    {
        int arrLength = int.Parse(Console.ReadLine());
        int[] indexTaken = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] arr = new int[arrLength];

        for (int i = 0; i < indexTaken.Length; i++)
        {
            int currentIndex = indexTaken[i];
            if (currentIndex >= 0 && currentIndex < arr.Length)
            {
                arr[currentIndex] = 1;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] elements = command.Split();
            int indexMoving = int.Parse(elements[0]);
            string direction = elements[1];
            int flyLength = int.Parse(elements[2]);

            if (indexMoving < 0 ||
                indexMoving > arr.Length - 1 ||
                arr[indexMoving] == 0)
            {
                continue;
            }

            arr[indexMoving] = 0;

            if (direction == "right")
            {
                int indexToGoR = indexMoving + flyLength;

                if (indexToGoR > arr.Length - 1)
                {
                    continue;
                }

                if (arr[indexToGoR] == 1)
                {
                    while (arr[indexToGoR] == 1)
                    {
                        indexToGoR += flyLength;
                        if (indexToGoR > arr.Length - 1)
                        {
                            break;
                        }
                    }
                }

                if (indexToGoR <= arr.Length - 1)
                {
                    arr[indexToGoR] = 1;
                }
            }
            else if (direction == "left")
            {
                int indexToGoL = indexMoving - flyLength;

                if (indexToGoL < 0)
                {
                    continue;
                }

                if (arr[indexToGoL] == 1)
                {
                    while (arr[indexToGoL] == 1)
                    {
                        indexToGoL -= flyLength;
                        if (indexToGoL < 0)
                        {
                            break;
                        }
                    }
                }

                if (indexToGoL >= 0)
                {
                    arr[indexToGoL] = 1;
                }
            }
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}