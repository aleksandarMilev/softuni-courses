namespace MusicHub.DBContext
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Models;

    public class MusicHubContext : DbContext
    {
        private readonly string ConnectionString =
            "Server = .\\SQLEXPRESS; Database = MusicHub; Integrated Security = True; TrustServerCertificate = true";

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .Property(s => s.Genre)
                .HasConversion<string>();
        }
    }
}