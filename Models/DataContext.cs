using Microsoft.EntityFrameworkCore;

namespace MilkingPigeons.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
