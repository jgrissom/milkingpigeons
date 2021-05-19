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
        public DbSet<TeamChallenge> TeamChallenges { get; set; }
        public Team AddTeam(Team team)
        {
            this.Teams.Add(team);
            this.SaveChanges();
            return team;
        }
        // public void RenameTeam(Team team)
        // {
        //     Team savedTeam = this.Teams.FirstOrDefault(t => t.TeamId == team.TeamId);
        //     savedTeam.Name = team.Name;
        //     this.SaveChanges();
        // }
        public int AddTeamChallenge(TeamChallenge teamChallenge)
        {
            this.TeamChallenges.Add(teamChallenge);
            this.SaveChanges();
            return teamChallenge.TeamChallengeId;
        }
    }
}
