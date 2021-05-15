using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace MilkingPigeons.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public Team AddTeam(string Name)
        {
            // TODO: create team
            //Team team = new Team { Name = Name, Pin = Convert.ToString(next_pin)};
            return null;
        }
    }
}
