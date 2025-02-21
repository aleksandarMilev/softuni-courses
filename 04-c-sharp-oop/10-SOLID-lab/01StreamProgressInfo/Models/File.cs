namespace StreamProgressInfo.Models
{
    public class File
    {
        public File(string name, int length, int bytesSent)
        {
            Name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public string Name { get; private set; }
        public int Length { get; private set; }
        public int BytesSent { get; private set; }
    }
}
