using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Interfaces
{
    public interface ITeamLogic
    {
        void Create(Team teamcreate);
        void Delete(int id);
        IEnumerable<Team> ReadAll();
        Team Read(int id);
        void Update(Team teamupdate);
    }
}
