namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] sourceBytes = File.ReadAllBytes(sourceFilePath);

            int partOneSize = (int)Math.Ceiling(sourceBytes.Length / 2.0);
            int partTwoSize = sourceBytes.Length - partOneSize;

            byte[] partOneBytes = new byte[partOneSize];
            byte[] partTwoBytes = new byte[partTwoSize];

            Array.Copy(sourceBytes, 0, partOneBytes, 0, partOneSize);
            Array.Copy(sourceBytes, partOneSize, partTwoBytes, 0, partTwoSize);

            File.WriteAllBytes(partOneFilePath, partOneBytes);
            File.WriteAllBytes(partTwoFilePath, partTwoBytes);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOneBytes = File.ReadAllBytes(partOneFilePath);
            byte[] partTwoBytes = File.ReadAllBytes(partTwoFilePath);

            byte[] mergedBytes = new byte[partOneBytes.Length + partTwoBytes.Length];
            Array.Copy(partOneBytes, mergedBytes, partOneBytes.Length);
            Array.Copy(partTwoBytes, 0, mergedBytes, partOneBytes.Length, partTwoBytes.Length);

            File.WriteAllBytes(joinedFilePath, mergedBytes);
        }
    }
}