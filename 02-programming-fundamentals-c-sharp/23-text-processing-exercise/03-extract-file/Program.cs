using System;
namespace _03ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;
            string extensionName = string.Empty;

            string input = Console.ReadLine();

            int lastSeparatorIndex = input.LastIndexOf("\\");
            int extensionIndex = input.LastIndexOf(".");

            if (lastSeparatorIndex != - 1 &&
                extensionIndex != - 1 &&
                extensionIndex > lastSeparatorIndex)
            {
                fileName = input.Substring(lastSeparatorIndex + 1,
                    extensionIndex - lastSeparatorIndex - 1);

                extensionName = input.Substring(extensionIndex + 1);
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extensionName}");
        }
    }
}