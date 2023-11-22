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
            Game wow = new Game();
            Game dota = new Game();
            Game lol = new Game();
            Game cs = new Game();
            Team jdg = new Team { Id = 1, TeamName = "JD Gaming", CountryOfOrigin = "China", MultipleGamesPlayed = false };
            Team nrg = new Team { Id = 2, TeamName = "NRG", CountryOfOrigin = "United States", MultipleGamesPlayed = false };
            Team bds = new Team { Id = 3, TeamName = "Team BDS", CountryOfOrigin = "France", MultipleGamesPlayed = false };
            Team gg = new Team { Id = 16, TeamName = "Golden Guardians", CountryOfOrigin = "United States", MultipleGamesPlayed = true };
            var wowplayers = new List<Player>
            {
                new Player { Id = 1, IngameName = "Raiku", YearsActive = 2, TeamId = 1, GameId = 1, Salary = 274135, LeagueChampion = true ,Team=jdg,game=wow},
                new Player { Id = 2, IngameName = "Whaazz", YearsActive = 5, TeamId = 1, GameId = 1, Salary = 691542, LeagueChampion = false ,Team=jdg,game=wow},
                new Player { Id = 3, IngameName = "TheShy", YearsActive = 4, TeamId = 1, GameId = 1, Salary = 447813, LeagueChampion = true ,Team=jdg,game=wow},
                  new Player { Id = 4, IngameName = "Dopa", YearsActive = 4, TeamId = 1, GameId = 1, Salary = 447813, LeagueChampion = true ,Team=jdg,game=wow}
            };
            var lolplayers = new List<Player>
            {
    new Player { Id = 11, IngameName = "Faker", YearsActive = 5, TeamId = 11, GameId = 4, Salary = 234567, LeagueChampion = true ,Team=bds,game=lol},
    new Player { Id = 12, IngameName = "Gumayusi", YearsActive = 4, TeamId = 12, GameId = 4, Salary = 567890, LeagueChampion = false ,Team=bds,game=lol},
    new Player { Id = 13, IngameName = "Keria", YearsActive = 3, TeamId = 13, GameId = 4, Salary = 432109, LeagueChampion = true ,Team=bds,game=lol},
            };
            var csplayers = new List<Player>
            {
    new Player { Id = 23, IngameName = "m0nesy", YearsActive = 5, TeamId = 8, GameId = 3, Salary = 279485, LeagueChampion = true,Team=nrg,game=cs },
    new Player { Id = 24, IngameName = "jks", YearsActive = 4, TeamId = 9, GameId = 3, Salary = 746152, LeagueChampion = false ,Team=nrg,game=cs},
    new Player { Id = 25, IngameName = "Hooxi", YearsActive = 3, TeamId = 10, GameId = 3, Salary = 513497, LeagueChampion = true ,Team=nrg,game=cs},
            };
            var dotaplayers = new List<Player>
            {
                new Player { Id = 1, IngameName = "miCKE", YearsActive = 3, TeamId = 1, GameId = 2, Salary = 274135, LeagueChampion = true ,Team=gg,game=dota},
                new Player { Id = 2, IngameName = "Insania", YearsActive = 5, TeamId = 2, GameId = 2, Salary = 691542, LeagueChampion = false,Team=gg,game=dota},
                new Player { Id = 3, IngameName = "Boxiaz", YearsActive = 4, TeamId = 3, GameId = 2, Salary = 447813, LeagueChampion = true,Team=gg,game=dota },
            };
             wow = new Game { Id = 1, GameName = "World of Warcraft", LeagueName = "Arena World Championship", Developer = "Blizzard Entertainment", ReleaseDate = 2004, Players = wowplayers };
             dota = new Game { Id = 2, GameName = "Dota 2", LeagueName = "The International", Developer = "Valve Corporation", ReleaseDate = 2013, Players = dotaplayers };
             cs = new Game { Id = 3, GameName = "CS:GO", LeagueName = "Majors", Developer = "Valve Corporation", ReleaseDate = 2012, Players = csplayers };
             lol = new Game { Id = 4, GameName = "League of Legends", LeagueName = "Worlds", Developer = "Riot Games", ReleaseDate = 2009, Players = lolplayers };
            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>()
            {
                wow,dota,cs,lol
            }.AsQueryable());
            logic = new GameLogic(mockGameRepo.Object);
        }
        [Test]
        public void MostPlayersInAGameTest()
        {
            string result = logic.MostPlayersInAGame();
            Assert.That(result == "World of Warcraft");

        }
        [Test]
        public void ChinesePlayersWithExpTest()
        {
            var result = logic.ChinesePlayersWithExp();
            Assert.That(result.Count() == 3 && result.Contains("Whaazz") && result.Contains("TheShy") && result.Contains("Dopa"));
        }
        [Test]
        public void GameWithMostChinesePlayersTest()
        {
            string result = logic.GameWithMostChineseTeams();
            Assert.That(result == "World of Warcraft");
        }
        [Test]
        public void GameWithHighestSalaryTest()
        {
            string result = logic.GameWithHighestAverageSalary();
            Assert.That(result == "CS:GO");
        }
    }
}
