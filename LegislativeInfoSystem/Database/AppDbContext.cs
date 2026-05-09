using LegislativeInfoSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegislativeInfoSystem.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Legislator> Legislators { get; set; }
        public DbSet<Legislation> Legislation { get; set; }
    }
}
