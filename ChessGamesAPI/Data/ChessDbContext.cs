using ChessGamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChessGamesAPI.Data
{
    public class ChessDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public ChessDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<ChessGame> chessGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChessGame>().ToTable("Pgn");

            // Configure other aspects of your entity here, such as keys, relationships, etc.
        }
    }
}
