namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytesToExtract = File.ReadAllLines(bytesFilePath)
                            .Select(byteStr => Convert.ToByte(byteStr))
                            .ToArray();

            byte[] inputBytes = File.ReadAllBytes(binaryFilePath);

            using (FileStream writer = new FileStream(outputPath, FileMode.Create))
            foreach (byte byteToExtract in bytesToExtract)
            {
                foreach (byte inputByte in inputBytes)
                {
                    if (inputByte == byteToExtract)
                    {
                        writer.WriteByte(inputByte);
                    }
                }
            }
        }
    }
}
