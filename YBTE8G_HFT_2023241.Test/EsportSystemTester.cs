using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YBTE8G_HFT_2023241.Logic;
using YBTE8G_HFT_2023241.Repository;
using YBTE8G_HFT_2023241.Models;
using Moq;
using YBTE8G_HFT_2023241.Logic.Services;
using YBTE8G_HFT_2023241.Repository.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace YBTE8G_HFT_2023241.Test
{
    [TestFixture]
    public class EsportSystemTester
    {
        GameLogic logic;

        Mock<IRepository<Game>> mockGameRepo;
        [SetUp]
        public void Init()
        {
            Team jdg = new Team { Id = 1, TeamName = "JD Gaming", CountryOfOrigin = "China", MultipleGamesPlayed = true };
            Team nrg = new Team { Id = 2, TeamName = "NRG", CountryOfOrigin = "United States", MultipleGamesPlayed = true };
            Team bds = new Team { Id = 3, TeamName = "Team BDS", CountryOfOrigin = "France", MultipleGamesPlayed = true };
            var wowplayers = new List<Player>
            {
                new Player { Id = 1, IngameName = "Raiku", YearsActive = 3, TeamId = 1, GameId = 1, Salary = 274135, LeagueChampion = true ,Team=jdg},
                new Player { Id = 2, IngameName = "Whaazz", YearsActive = 5, TeamId = 1, GameId = 1, Salary = 691542, LeagueChampion = false ,Team=jdg},
                new Player { Id = 3, IngameName = "TheShy", YearsActive = 4, TeamId = 1, GameId = 1, Salary = 447813, LeagueChampion = true ,Team=jdg},
                  new Player { Id = 4, IngameName = "Dopa", YearsActive = 4, TeamId = 1, GameId = 1, Salary = 447813, LeagueChampion = true ,Team=jdg}
            };
            var lolplayers = new List<Player>
            {
    new Player { Id = 11, IngameName = "Faker", YearsActive = 5, TeamId = 11, GameId = 4, Salary = 234567, LeagueChampion = true ,Team=bds},
    new Player { Id = 12, IngameName = "Gumayusi", YearsActive = 4, TeamId = 12, GameId = 4, Salary = 567890, LeagueChampion = false ,Team=bds},
    new Player { Id = 13, IngameName = "Keria", YearsActive = 3, TeamId = 13, GameId = 4, Salary = 432109, LeagueChampion = true ,Team=bds},
            };
            var csplayers = new List<Player>
            {
    new Player { Id = 23, IngameName = "m0nesy", YearsActive = 5, TeamId = 8, GameId = 3, Salary = 279485, LeagueChampion = true,Team=nrg },
    new Player { Id = 24, IngameName = "jks", YearsActive = 4, TeamId = 9, GameId = 3, Salary = 746152, LeagueChampion = false ,Team=nrg},
    new Player { Id = 25, IngameName = "Hooxi", YearsActive = 3, TeamId = 10, GameId = 3, Salary = 513497, LeagueChampion = true ,Team=nrg},
            };
            var dotaplayers = new List<Player>
            {
                new Player { Id = 1, IngameName = "Raiku", YearsActive = 3, TeamId = 1, GameId = 2, Salary = 274135, LeagueChampion = true },
                new Player { Id = 2, IngameName = "Whaazz", YearsActive = 5, TeamId = 2, GameId = 2, Salary = 691542, LeagueChampion = false },
                new Player { Id = 3, IngameName = "TheShy", YearsActive = 4, TeamId = 3, GameId = 2, Salary = 447813, LeagueChampion = true },
            };
            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>()
            {
            new Game { Id=1,GameName = "World of Warcraft", LeagueName = "Arena World Championship", Developer = "Blizzard Entertainment", ReleaseDate = 2004,Players=wowplayers },
             new Game { Id=2,GameName = "Dota 2", LeagueName = "The International", Developer = "Valve Corporation", ReleaseDate = 2013, Players=dotaplayers },
            new Game { Id=3,GameName = "CS:GO", LeagueName = "Majors", Developer = "Valve Corporation", ReleaseDate = 2012 , Players=csplayers},
             new Game { Id=4,GameName = "League of Legends", LeagueName = "Worlds", Developer = "Riot Games", ReleaseDate = 2009 ,Players=lolplayers},
            }.AsQueryable());
            logic = new GameLogic(mockGameRepo.Object);
        }
        [Test]
        public void MostPlayersInAGame()
        {
            string result = logic.MostPlayersInAGame();
            Assert.That(result == "World of Warcraft");

        }
    }
}
