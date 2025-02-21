namespace MusicHub
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.DBContext;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main()
        {
            using MusicHubContext dbContext = new();
        }

        public static async Task<string> ExportAlbumsInfo(MusicHubContext context, int producerId)
        {
            var albums = await context.Albums
                .AsNoTracking()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new 
                        {
                            s.Name,
                            Price = s.Price.ToString("f2"),
                            WriterName = s.Writer.Name
                        })
                        .ToArray(),

                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("f2")
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArrayAsync();

            StringBuilder builder = new();

            if (albums.Length > 0)
            {
                foreach (var a in albums)
                {
                    builder.AppendLine($"-AlbumName: {a.Name}");
                    builder.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                    builder.AppendLine($"-ProducerName: {a.ProducerName}");

                    if (a.Songs.Length > 0)
                    {
                        builder.AppendLine($"-Songs:");

                        int counter = 0;

                        foreach (var s in a.Songs)
                        {
                            builder.AppendLine($"---#{++counter}");
                            builder.AppendLine($"---SongName: {s.Name}");
                            builder.AppendLine($"---Price: {s.Price}");
                            builder.AppendLine($"---Writer: {s.WriterName}");
                        }
                    }

                    builder.AppendLine($"--AlbumPrice: {a.AlbumPrice}");
                }
            }

            return builder
                .ToString()
                .TrimEnd();
        }

        public static async Task<string> ExportSongsAboveDuration(MusicHubContext context, int duration)
        {
            var songs = await context.Songs
                .AsNoTracking()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Include(s => s.SongPerformers) 
                .ThenInclude(sp => sp.Performer)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performers = s.SongPerformers
                        .OrderBy(sp => sp.Performer.FirstName)
                        .ThenBy(sp => sp.Performer.LastName)
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .ToList(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString(@"hh\:mm\:ss"),
                })
                .ToListAsync();

            StringBuilder builder = new();

            if (songs.Count > 0)
            {
                int counter = 0;

                foreach (var s in songs)
                {
                    builder.AppendLine($"-Song #{++counter}");
                    builder.AppendLine($"---SongName: {s.SongName}"); 
                    builder.AppendLine($"---Writer: {s.Writer}");

                    if (s.Performers.Count > 0)
                    {
                        foreach (var p in s.Performers)
                        {
                            builder.AppendLine($"---Performer: {p}");
                        }
                    }

                    builder.AppendLine($"---AlbumProducer: {s.AlbumProducer}"); 
                    builder.AppendLine($"---Duration: {s.Duration}");
                }
            }

            return builder
                .ToString()
                .TrimEnd();
        }
    }
}
