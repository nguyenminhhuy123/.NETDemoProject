using Microsoft.EntityFrameworkCore;

namespace Asp.net_core.Models
{
    public class TestDbcontext : DbContext
    {
        public TestDbcontext(DbContextOptions<TestDbcontext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<Receipt> Receipts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
            .HasOne(a => a.Car)
            .WithOne(b => b.receipts)
            .HasForeignKey<Receipt>(c => c.IdCar);

            modelBuilder.Entity<Receipt>()
            .HasOne(a => a.Owner)
            .WithMany(b => b.Receipts)
            .HasForeignKey(c => c.IdOwner);

            modelBuilder.Entity<Receipt>()
            .HasOne(a => a.Vendor)
            .WithMany(b => b.Receipts)
            .HasForeignKey(c => c.IdVendor);
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<Car>().ToTable("Car");
        }
    }
}