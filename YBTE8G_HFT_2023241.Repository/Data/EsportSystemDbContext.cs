using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.SqlServer;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic
{
    public partial class EsportSystemDbContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public EsportSystemDbContext()
        {
            this.Database.EnsureCreated();
        }
        public EsportSystemDbContext(DbContextOptions<EsportSystemDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
              .UseInMemoryDatabase("esportdb")
              .UseLazyLoadingProxies();


            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(student => student.Team)
                .WithMany(classes => classes.Players)
                .HasForeignKey(student => student.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Player>(entity =>
            {
                entity
                .HasOne(student => student.game)
                .WithMany(classes => classes.Players)
                .HasForeignKey(student => student.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            List<Team> teams = new List<Team>
{
    new Team { Id=1,TeamName = "Bilibili Gaming", CountryOfOrigin = "China", MultipleGamesPlayed = true },
    new Team { Id=2,TeamName = "JD Gaming", CountryOfOrigin = "China", MultipleGamesPlayed = true },
    new Team { Id=3,TeamName = "NRG", CountryOfOrigin = "United States", MultipleGamesPlayed = true },
    new Team { Id=4,TeamName = "Gen.G", CountryOfOrigin = "South Korea", MultipleGamesPlayed = true },
    new Team { Id=5,TeamName = "LNG Esports", CountryOfOrigin = "China", MultipleGamesPlayed = true },
    new Team { Id=6,TeamName = "Fnatic", CountryOfOrigin = "United Kingdom", MultipleGamesPlayed = true },
    new Team { Id=7,TeamName = "G2 Esports", CountryOfOrigin = "Spain", MultipleGamesPlayed = true },
    new Team { Id=8,TeamName = "Cloud9", CountryOfOrigin = "United States", MultipleGamesPlayed = true },
    new Team { Id=9,TeamName = "MAD Lions", CountryOfOrigin = "Spain", MultipleGamesPlayed = true },
    new Team { Id=10,TeamName = "Team Liquid", CountryOfOrigin = "United States", MultipleGamesPlayed = true },
    new Team { Id=11,TeamName = "Team BDS", CountryOfOrigin = "France", MultipleGamesPlayed = true },
    new Team { Id=12,TeamName = "Weibo Gaming", CountryOfOrigin = "China", MultipleGamesPlayed = true },
    new Team { Id=13,TeamName = "T1", CountryOfOrigin = "South Korea", MultipleGamesPlayed = true },
    new Team { Id=14,TeamName = "Echo Esports", CountryOfOrigin = "Brazil", MultipleGamesPlayed = true },
    new Team { Id=15,TeamName = "Luminosity Gaming", CountryOfOrigin = "United States", MultipleGamesPlayed = true },
    new Team { Id=16,TeamName = "Golden Guardians", CountryOfOrigin = "United States", MultipleGamesPlayed = true },
};
            List<Game> games = new List<Game>
{
    new Game { Id=1,GameName = "World of Warcraft", LeagueName = "Arena World Championship", Developer = "Blizzard Entertainment", ReleaseDate = 2004 },
    new Game { Id=2,GameName = "Dota 2", LeagueName = "The International", Developer = "Valve Corporation", ReleaseDate = 2013 },
    new Game { Id=3,GameName = "CS:GO", LeagueName = "Majors", Developer = "Valve Corporation", ReleaseDate = 2012 },
    new Game { Id=4,GameName = "League of Legends", LeagueName = "Worlds", Developer = "Riot Games", ReleaseDate = 2009 },
};
            List<Player> players = new List<Player>
{
    new Player { Id = 1, IngameName = "Raiku", YearsActive = 3, TeamId = 1, GameId = 1, Salary = 274135, LeagueChampion = true },
    new Player { Id = 2, IngameName = "Whaazz", YearsActive = 5, TeamId = 2, GameId = 2, Salary = 691542, LeagueChampion = false },
    new Player { Id = 3, IngameName = "TheShy", YearsActive = 4, TeamId = 3, GameId = 3, Salary = 447813, LeagueChampion = true },
    new Player { Id = 4, IngameName = "Weiwei", YearsActive = 3, TeamId = 4, GameId = 4, Salary = 154267, LeagueChampion = false },
    new Player { Id = 5, IngameName = "Crownie", YearsActive = 4, TeamId = 5, GameId = 1, Salary = 845719, LeagueChampion = true },
    new Player { Id = 6, IngameName = "Adam", YearsActive = 2, TeamId = 6, GameId = 2, Salary = 512684, LeagueChampion = false },
    new Player { Id = 7, IngameName = "Humanoid", YearsActive = 4, TeamId = 7, GameId = 3, Salary = 356027, LeagueChampion = true },
    new Player { Id = 8, IngameName = "Razork", YearsActive = 3, TeamId = 8, GameId = 4, Salary = 726491, LeagueChampion = false },
    new Player { Id = 9, IngameName = "Yagao", YearsActive = 4, TeamId = 9, GameId = 1, Salary = 123456, LeagueChampion = true },
    new Player { Id = 10, IngameName = "XUN", YearsActive = 3, TeamId = 10, GameId = 2, Salary = 789012, LeagueChampion = false },
    new Player { Id = 11, IngameName = "Faker", YearsActive = 5, TeamId = 11, GameId = 3, Salary = 234567, LeagueChampion = true },
    new Player { Id = 12, IngameName = "Gumayusi", YearsActive = 4, TeamId = 12, GameId = 4, Salary = 567890, LeagueChampion = false },
    new Player { Id = 13, IngameName = "Keria", YearsActive = 3, TeamId = 13, GameId = 1, Salary = 432109, LeagueChampion = true },
    new Player { Id = 14, IngameName = "Kanavi", YearsActive = 4, TeamId = 14, GameId = 2, Salary = 654321, LeagueChampion = false },
    new Player { Id = 15, IngameName = "369", YearsActive = 5, TeamId = 15, GameId = 3, Salary = 890123, LeagueChampion = true },
    new Player { Id = 16, IngameName = "Palafox", YearsActive = 4, TeamId = 1, GameId = 4, Salary = 135790, LeagueChampion = false },
    new Player { Id = 17, IngameName = "Caps", YearsActive = 3, TeamId = 2, GameId = 1, Salary = 468135, LeagueChampion = true },
    new Player { Id = 18, IngameName = "Hans Sama", YearsActive = 4, TeamId = 16, GameId = 2, Salary = 790246, LeagueChampion = false },
    new Player { Id = 19, IngameName = "BrokenBlade", YearsActive = 2, TeamId = 4, GameId = 3, Salary = 109357, LeagueChampion = true },
    new Player { Id = 20, IngameName = "Chovy", YearsActive = 4, TeamId = 5, GameId = 4, Salary = 246801, LeagueChampion = false },
    new Player { Id = 21, IngameName = "Nisqy", YearsActive = 3, TeamId = 6, GameId = 1, Salary = 580139, LeagueChampion = true },
    new Player { Id = 22, IngameName = "Carzzy", YearsActive = 4, TeamId = 7, GameId = 2, Salary = 913824, LeagueChampion = false },
    new Player { Id = 23, IngameName = "m0nesy", YearsActive = 5, TeamId = 8, GameId = 3, Salary = 279485, LeagueChampion = true },
    new Player { Id = 24, IngameName = "jks", YearsActive = 4, TeamId = 9, GameId = 4, Salary = 746152, LeagueChampion = false },
    new Player { Id = 25, IngameName = "Hooxi", YearsActive = 3, TeamId = 10, GameId = 1, Salary = 513497, LeagueChampion = true },
    new Player { Id = 26, IngameName = "Swani", YearsActive = 4, TeamId = 11, GameId = 2, Salary = 687235, LeagueChampion = false },
    new Player { Id = 27, IngameName = "miCKE", YearsActive = 2, TeamId = 12, GameId = 3, Salary = 924876, LeagueChampion = true },
    new Player { Id = 28, IngameName = "Insania", YearsActive = 3, TeamId = 16, GameId = 4, Salary = 361294, LeagueChampion = false },
    new Player { Id = 29, IngameName = "Boxiaz", YearsActive = 2, TeamId = 14, GameId = 1, Salary = 632145, LeagueChampion = true }
};

            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<Team>().HasData(teams);
        }
        
    }
}
