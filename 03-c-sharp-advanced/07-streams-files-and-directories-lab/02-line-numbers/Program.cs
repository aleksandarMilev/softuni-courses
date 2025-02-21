namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new(inputFilePath);
            using StreamWriter writer = new(outputFilePath);

            int lineNumber = 1;
            string line = string.Empty;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                writer.WriteLine($"{lineNumber}. {line}");
                lineNumber++;
            }
        }
    }
}
