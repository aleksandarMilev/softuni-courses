namespace CarDealer.Context
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerContext : DbContext
    {
        private readonly string ConnectionString =
            "Server = .\\SQLEXPRESS; Database = CarDealer; Integrated Security = True; TrustServerCertificate = true";

        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions contextOptions) 
            : base(contextOptions) 
        { 
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartsCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new { k.CarId, k.PartId });
            });
        }
    }
}
