using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> gameRepo;
        IPlayerLogic playerLogic;
        ITeamLogic teamLogic;
        public GameLogic(IRepository<Game> repo)
        {
            gameRepo = repo;
        }
        public void Create(Game course)
        {
            gameRepo.Create(course);
        }

        public void Delete(int id)
        {
           gameRepo.Delete(id);
        }

        public Game Read(int id)
        {
            return gameRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel játékot");
        }

        public IEnumerable<Game> ReadAll()
        {
            return gameRepo.ReadAll();
        }

        public string MostPlayersInAGame()
        {
            var gameWithMostPlayers = gameRepo.ReadAll()
       .OrderByDescending(g => g.Players.Count).First();
            return gameWithMostPlayers.GameName;
        }
        public IEnumerable<string> ChinesePlayersWithExp()
        {
            var result = gameRepo.ReadAll()
                   .SelectMany(game => game.Players)
                   .Where(player => player.Team.CountryOfOrigin == "China" && player.YearsActive > 3)
                   .Select(player => player.IngameName);
            return result.ToList();
        }
        public string GameWithHighestAverageSalary()
        {
            return gameRepo.ReadAll()
                .Select(game => new
                {
                    GameName = game.GameName,
                    AverageSalary = game.Players.Average(player => player.Salary)
                })
                .OrderByDescending(game => game.AverageSalary)
                .FirstOrDefault().GameName;
        }
        public string GameWithMostChineseTeams()
        {
            return gameRepo.ReadAll()
                .Select(game => new
                {
                    GameName = game.GameName,
                    ChineseTeamCount = game.Players.Count(player => player.Team.CountryOfOrigin == "China")
                })
                .OrderByDescending(game => game.ChineseTeamCount)
                .FirstOrDefault().GameName;
        }
        public void Update(Game course)
        {
            gameRepo.Update(course);
        }
    }
}
