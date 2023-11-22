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
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> teamRepo;
        public TeamLogic(IRepository<Team> repo)
        {
            teamRepo = repo;
        }
        public void Create(Team classcreate)
        {
            teamRepo.Create(classcreate);
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
        public string TeamWithHighestAverageSalaryInAGame(string game)
        {
            var teamWithHighestAverageSalary = teamRepo.ReadAll()
                .OrderByDescending(team => team.Players
                    .Where(player => player.game.GameName == game)
                    .Average(player => player.Salary))
                .FirstOrDefault();

            return teamWithHighestAverageSalary.TeamName;
        }
        public Team Read(int id)
        {
            return teamRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel csapatot");
        }

        public IEnumerable<Team> ReadAll()
        {
            return teamRepo.ReadAll();
        }

        public void Update(Team classupdate)
        {
            teamRepo.Update(classupdate);
        }
    }
}
