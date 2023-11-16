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
    public class PlayerRepostiory : Repository<Player>, IPlayerRepository
    {
        public PlayerRepostiory(EsportSystemDbContext ctx) : base(ctx)
        {

        }
        public void UpdateIngameName(int id,string IngameName)
        {
            Player old = Read(id);
            old.IngameName = IngameName;
            ctx.SaveChanges();
        }
    }
}
