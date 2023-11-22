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
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(EsportSystemDbContext ctx) : base(ctx)
        {
        }
        public void UpdateLeagueName(int id,string LeagueName)
        {
            Game old = Read(id);
            old.LeagueName = LeagueName;
            ctx.SaveChanges();
        }
    }
}
