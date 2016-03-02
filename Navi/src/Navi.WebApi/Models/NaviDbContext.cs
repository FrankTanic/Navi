using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Navi.WebApi.Models
{
    public class NaviDbContext : DbContext
    {
        public NaviDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Locations> Location { get; set; }
        public DbSet<Coordinates> Coordinate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>()
                .HasOne(c => c.Coordinate)
                .WithOne(l => l.Location)
                .HasForeignKey<Coordinates>(c => c.LocationForeignKey);
        }
    }
}