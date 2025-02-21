namespace StreamProgressInfo.Models
{
    public class Music : File
    {
        public Music(string artist, string album, int length, int bytesSent)
            : base(artist, length, bytesSent)
        {
            Artist = artist;
            Album = album;
        }

        public string Artist { get; private set; }
        public string Album { get; private set; }
    }
}
