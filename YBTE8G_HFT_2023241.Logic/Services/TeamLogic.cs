﻿using System;
using System.Collections.Generic;
using System.Linq;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> teamRepo;
        public TeamLogic(IRepository<Team> repo)
        {
            teamRepo = repo;
        }
        public void Create(Team teamcreate)
        {
            teamRepo.Create(teamcreate);
        }

        public void Delete(int id)
        {
            teamRepo.Delete(id);
        }
        public string TeamWithMostLoLPlayers()
        {
            var teamWithMostLoLPlayers = teamRepo.ReadAll()
                .OrderByDescending(team => team.Players.Count(player => player.game.GameName == "League of Legends"))
                .FirstOrDefault();

            return teamWithMostLoLPlayers.TeamName;
        }
        public Team Read(int id)
        {
            return teamRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel csapatot");
        }

        public IEnumerable<Team> ReadAll()
        {
            return teamRepo.ReadAll();
        }

        public void Update(Team teamupdate)
        {
            teamRepo.Update(teamupdate);
        }
    }
}
