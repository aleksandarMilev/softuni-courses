namespace LineNumbers
{
    using System;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new();

            string[] fileArr = File.ReadAllLines(inputFilePath);
            int lineNumber = 1;

            foreach (string line in fileArr)
            {
                int lettersCount = 0;
                int punctuationsCount = 0;
                foreach (char c in line)
                {
                    if (char.IsPunctuation(c))
                    {
                        punctuationsCount++;
                    }
                    else if (char.IsLetter(c))
                    {
                        lettersCount++;
                    }
                }

                sb = sb.Append($"Line {lineNumber}: {line} ({lettersCount})({punctuationsCount})" + Environment.NewLine);
                lineNumber++;
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
