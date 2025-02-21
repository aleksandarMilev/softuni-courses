using System;
namespace _03Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split("_");
                string typeList = command[0];
                string songName = command[1];
                string songTime = command[2];

                Song song = new Song(typeList, songName, songTime);
                playlist.Add(song);
            }

            string filter = Console.ReadLine();

            if (filter != "all")
            {
                foreach (Song song in playlist)
                {
                    if (filter == song.TypeList)
                    {
                        Console.WriteLine(song.SongName);
                    }
                }
                return;
            }

            foreach (Song song in playlist)
            {
                Console.WriteLine(song.SongName);
            }
        }
    }

    public class Song
    {
        public Song(string typeList, string songName, string songTime)
        {
            TypeList = typeList;
            SongName = songName;
            SongTime = songTime;
        }

        public string TypeList { get; set; }

        public string SongName { get; set; }

        public string SongTime { get; set; }
    }
}