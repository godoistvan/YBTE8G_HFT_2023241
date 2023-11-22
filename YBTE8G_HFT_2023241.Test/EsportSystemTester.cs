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
            mockGameRepo= new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>()
            {
            new Game { Id=1,GameName = "World of Warcraft", LeagueName = "Arena World Championship", Developer = "Blizzard Entertainment", ReleaseDate = 2004 },
             new Game { Id=2,GameName = "Dota 2", LeagueName = "The International", Developer = "Valve Corporation", ReleaseDate = 2013 },
            new Game { Id=3,GameName = "CS:GO", LeagueName = "Majors", Developer = "Valve Corporation", ReleaseDate = 2012 },
             new Game { Id=4,GameName = "League of Legends", LeagueName = "Worlds", Developer = "Riot Games", ReleaseDate = 2009 },
            }.AsQueryable());
            logic = new GameLogic(mockGameRepo.Object);
        }
    }
}
