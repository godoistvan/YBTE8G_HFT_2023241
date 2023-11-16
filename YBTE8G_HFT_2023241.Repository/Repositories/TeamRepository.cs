using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Repository.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(EsportSystemDbContext ctx) : base(ctx)
        {

        }
        public void UpdateTeamName(int id,string TeamName)
        {
            Team old = Read(id);
            old.TeamName = TeamName;
            ctx.SaveChanges();
        }
    }
}
