using System.IO;
using UniversityCompetition.IO.Contracts;

namespace UniversityCompetition.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using StreamWriter sw = new("../../../test.txt");

            sw.Write(message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllLines("../../../test.txt", message);

            File.AppendText("../../../test.txt");

            File.AppendAllLines
        }
    }
}
