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

        public override Game Read(int id)
        {
            return ctx.Games.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Game item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
