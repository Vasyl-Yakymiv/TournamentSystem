using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayInTournament> PlayInTournaments { get; set; }
        public DbSet<News> News { get; set; }
    }
}
