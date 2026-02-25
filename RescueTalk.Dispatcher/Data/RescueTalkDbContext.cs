using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Data
{
    public class RescueTalkDbContext : DbContext
    {
        public RescueTalkDbContext(DbContextOptions<RescueTalkDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
                .HasIndex(i => i.Code)
                .IsUnique();
        }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}