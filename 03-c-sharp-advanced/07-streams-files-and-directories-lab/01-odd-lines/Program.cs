namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new(inputFilePath);
            using StreamWriter writer = new(outputFilePath);

            int lineNumber = 0;
            string line = string.Empty;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (lineNumber % 2 != 0)
                {
                    writer.WriteLine(line);
                }

                lineNumber++;
            }
        }
    }
}
