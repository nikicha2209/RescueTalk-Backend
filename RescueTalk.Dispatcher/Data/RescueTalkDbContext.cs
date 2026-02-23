using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Data
{
    public class RescueTalkDbContext : DbContext
    {
        public RescueTalkDbContext(DbContextOptions<RescueTalkDbContext> options)
            : base(options) { }

        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}