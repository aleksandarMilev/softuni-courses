namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader reader1 = new(firstInputFilePath);
            using StreamReader reader2 = new(secondInputFilePath);
            using StreamWriter writer = new(outputFilePath);

            string line = string.Empty;
            while (!reader1.EndOfStream ||
                !reader2.EndOfStream)
            {
                line = reader1.ReadLine();
                writer.WriteLine(line);
                line = reader2.ReadLine();
                writer.WriteLine(line);
            }

            if (!reader1.EndOfStream)
            {
                while (!reader1.EndOfStream)
                {
                    line = reader1.ReadLine();
                    writer.WriteLine(line);
                }
            }
            else if (!reader2.EndOfStream)
            {
                while (!reader2.EndOfStream)
                {
                    line = reader2.ReadLine();
                    writer.WriteLine(line);
                }
            }

        }
    }
}
