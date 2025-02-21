namespace StudentSystem.DBContext
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Models;

    public class StudentSystemDbContext : DbContext
    {
        private readonly string ConnectionString =
            "Server = .\\SQLEXPRESS; Database = StudentSystem; Integrated Security = True; TrustServerCertificate = true";

        public StudentSystemDbContext()
        { }

        public StudentSystemDbContext(DbContextOptions<StudentSystemDbContext> contextOptions)
            : base(contextOptions)
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .Property(r => r.ResourceType)
                .HasConversion<string>();

            modelBuilder.Entity<Homework>()
                .Property(r => r.ContentType)
                .HasConversion<string>();
        }
    }
}
