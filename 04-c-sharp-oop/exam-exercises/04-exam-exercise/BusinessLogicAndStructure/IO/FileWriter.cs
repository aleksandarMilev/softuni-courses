using ChristmasPastryShop.IO.Contracts;
using System.IO;
namespace ChristmasPastryShop.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            string path = "../../../test.txt";

            using StreamWriter writer = new StreamWriter(path, true);

            writer.Write(message);
        }

        public void WriteLine(string message)
        {
            string path = "../../../test.txt";

            using StreamWriter writer = new StreamWriter(path, true);

            writer.WriteLine(message);
        }
    }
}
