using System;
using System.Collections.Generic;
namespace _10SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] arr = command.Split(":");
                string lessonTitle = arr[1];
                switch (arr[0])
                {
                    case "Add":
                        if (!list.Contains(lessonTitle))
                        {
                            list.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(arr[2]);

                        if (ValidIndex(list, index) &&
                            !list.Contains(lessonTitle))
                        {
                            list.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (list.Contains(lessonTitle))
                        {
                            if (list[list.IndexOf(lessonTitle) + 1] == $"{lessonTitle}-Exercise")
                            {
                                list.RemoveRange(list.IndexOf(lessonTitle), 2);
                            }
                            else
                            {
                                list.Remove(lessonTitle);
                            }
                        }
                        break;
                    case "Swap":
                        break;
                    case "Exercise":
                        if (list.Contains(lessonTitle))
                        {
                            if (list[list.IndexOf(lessonTitle) + 1] != $"{lessonTitle}-Exercise")
                            {
                                list.Insert(list.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
                            }
                        }
                        else
                        {
                            list.Add(lessonTitle);
                            list.Add($"{lessonTitle}-Exercise");
                        }
                        break;
                    default:
                        break;
                }
            }

            int i = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    i++;
                    Console.WriteLine($"{i}.{item}");
                }
            }
        }

        static bool ValidIndex(List<string> list, int index)
        {
            return index >= 0 && index < list.Count;
        }
    }
}