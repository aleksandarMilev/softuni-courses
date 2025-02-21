using System;
namespace _01ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] instuctions = command.Split(">>>");
                switch (instuctions[0])
                {
                    case "Contains":
                        string subtringText = instuctions[1];
                        if (text.Contains(subtringText))
                        {
                            Console.WriteLine($"{text} contains {subtringText}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string typeChange = instuctions[1];
                        int startIndex = int.Parse(instuctions[2]);
                        int endIndex = int.Parse(instuctions[3]);
                        string range = "";

                        if (typeChange == "Upper")
                        {
                            range = text.Substring(startIndex, endIndex - startIndex).ToUpper();
                        }
                        else if (typeChange == "Lower")
                        {
                            range = text.Substring(startIndex, endIndex - startIndex).ToLower();
                        }
                        text = text.Remove(startIndex, endIndex - startIndex).Insert(startIndex, range);
                        Console.WriteLine(text);
                        break;
                    case "Slice":
                        int startIndSlice = int.Parse(instuctions[1]);
                        int endIndSlice = int.Parse(instuctions[2]);

                        text = text.Remove(startIndSlice, endIndSlice - startIndSlice);
                        Console.WriteLine(text);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}