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
    }
}
