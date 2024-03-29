﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        public GameLogic(IRepository<Game> repo)
        {
            gameRepo = repo;
        }
        public void Create(Game game)
        {
            if (game.GameName=="Minecraft")
            {
                throw new ArgumentException("Sajnos ezt a játékot tiltott hozzáadni");
            }
            if (game.GameName==null)
            {
                throw new ArgumentNullException("Játéknév nélkül nincs játék");
            }
            gameRepo.Create(game);
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
                   .Select(player => player.IngameName)
                   .AsEnumerable();
            return result;
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
        public string GameWithMostLeagueChampions()
        {
            var gameWithMostChampions = gameRepo.ReadAll()
                .Select(game => new
                {
                    GameName = game.GameName,
                    LeagueChampionCount = game.Players.Count(player => player.LeagueChampion)
                })
                .OrderByDescending(game => game.LeagueChampionCount)
                .FirstOrDefault();

            return gameWithMostChampions?.GameName;
        }
        public void Update(Game game)
        {
            gameRepo.Update(game);
        }
    }
}
