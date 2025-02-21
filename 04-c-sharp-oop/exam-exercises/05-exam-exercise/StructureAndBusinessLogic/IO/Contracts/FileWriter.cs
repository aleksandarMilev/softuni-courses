using System.IO;

namespace CarRacing.IO.Contracts
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using StreamWriter writer = new StreamWriter("../../../test.txt", true);
            writer.Write(message);
        }

        public void WriteLine(string message)
        {
            using StreamWriter writer = new StreamWriter("../../../test.txt", true);
            writer.WriteLine(message);
        }
    }
}
