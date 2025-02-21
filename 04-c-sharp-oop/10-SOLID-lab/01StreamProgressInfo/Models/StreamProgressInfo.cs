namespace StreamProgressInfo.Models
{
    public class StreamProgressInfo
    {
        private File file;

        public StreamProgressInfo(File file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
            => file.BytesSent * 100 / file.Length;
    }
}
