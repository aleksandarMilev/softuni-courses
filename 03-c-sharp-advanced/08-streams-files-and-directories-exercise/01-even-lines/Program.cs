namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new(inputFilePath);

            StringBuilder sb = new();
            string line = string.Empty;
            int counter = 0;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (counter % 2 == 0)
                {
                    line = ReplaceSymbols(line);
                    line = ReverseText(line);
                    sb = sb.Append(line + Environment.NewLine);
                }

                counter++;
            }

            return sb.ToString();
        }

        private static string ReverseText(string line)
        {
            char[] symbolsToReplace = { '-', ',', '.', '!', '?'};
            foreach (char character in symbolsToReplace)
            {
                line = line.Replace(character, '@');
            }

            return line;
        }

        private static string ReplaceSymbols(string line)
        {
            string[] lineAsArr = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            line = string.Join(" ", lineAsArr);

            return line;
        }
    }
}
