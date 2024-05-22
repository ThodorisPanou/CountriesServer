using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CountriesServer.DTO;

namespace CountriesServer.DbContextClasses
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
