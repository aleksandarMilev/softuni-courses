using System;
using System.Collections.Generic;
namespace _08AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split()
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "merge":
                        int startIndex = int.Parse(arguments[1]);
                        int endIndex = int.Parse(arguments[2]);
                        MergeItems(list, startIndex, endIndex);
                        break;
                    case "divide":
                        int index = int.Parse(arguments[1]);
                        int partitions = int.Parse(arguments[2]);
                        DivideItem(list, index, partitions);
                        break;
                    default:
                        break;
                }
            }

            Console.Write(string.Join(" ", list));
        }
        static void MergeItems(List<string> list, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (list.Count > 1 &&
                startIndex < list.Count - 1)
            {
                string concatenatedItem = "";

                if (endIndex > list.Count - 1)
                {
                    endIndex = list.Count - 1;
                }

                for (int i = startIndex; i <= endIndex; i++)
                {
                    concatenatedItem = concatenatedItem += list[i];
                }

                list.RemoveRange(startIndex, endIndex - startIndex + 1);
                list.Insert(startIndex, concatenatedItem);
            }
        }

        static void DivideItem(List<string> list, int index, int partitions)
        {
            string dividedWord = list[index];
            string newWord = "";
            int currLengthCount = 0;
            int newWordLength = list[index].Length / partitions;

            if (dividedWord.Length % partitions == 0)
            {
                for (int i = 0; i < dividedWord.Length; i++)
                {
                    currLengthCount++;
                    if (currLengthCount <= newWordLength)
                    {
                        newWord = newWord += dividedWord[i];
                    }
                    else
                    {
                        newWord = newWord += " ";
                        currLengthCount = 0;
                        i--;
                    }
                }
            }
            else
            {
                int eachEqualPartLength = dividedWord.Length / partitions;
                int lastPartlength = eachEqualPartLength + (dividedWord.Length % partitions);

                int totalLengthOfTheEqualPart = eachEqualPartLength * (partitions - 1);
                string equalPartString = dividedWord.Substring(0, totalLengthOfTheEqualPart);

                dividedWord = dividedWord.Remove(0, totalLengthOfTheEqualPart);
                string lastPart = dividedWord;

                for (int i = 0; i < equalPartString.Length; i++)
                {
                    currLengthCount++;
                    if (currLengthCount <= eachEqualPartLength)
                    {
                        newWord = newWord += equalPartString[i];
                    }
                    else
                    {
                        newWord = newWord += " ";
                        currLengthCount = 0;
                        i--;
                    }
                }

                newWord = newWord += " " + lastPart;
            }

            list.RemoveAt(index);
            string[] newWordAsArr = newWord.Split(" ");
            list.InsertRange(index, newWordAsArr);
        }
    }
}