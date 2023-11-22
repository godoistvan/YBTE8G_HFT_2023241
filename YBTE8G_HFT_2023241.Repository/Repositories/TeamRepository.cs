using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Repository.Repositories
{
    public class TeamRepository : Repository<Team>, IRepository<Team>
    {
        public TeamRepository(EsportSystemDbContext ctx) : base(ctx)
        {

        }

        public override Team Read(int id)
        {
            return ctx.Teams.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Team item)
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

