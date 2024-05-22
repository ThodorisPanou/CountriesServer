using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CountriesServer.DTO;

namespace CountriesServer.DbContextClasses
{
    public class SessionDbContext : DbContext
    {
        public SessionDbContext(DbContextOptions<SessionDbContext> opts) : base(opts)
        {
        }

        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasKey(c => c.SessionID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
