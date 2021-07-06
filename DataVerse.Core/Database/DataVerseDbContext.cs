using DataVerse.Entities;
using DataVerse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataVerse.Database
{
    public class DataVerseDbContext : DbContext, IDataVerseDbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phones> Phones { get; set; }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Phones)
                .WithOne(b => b.Customer);

            modelBuilder.Entity<Customer>()
                .HasAlternateKey(a => a.Email);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Run Migration Commands
            // -------------------------
            // - Remove-Migration
            // - add-migration db_migrations
            // - update-database
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog= DataVerse; Integrated Security = true");
        }
    }
}
