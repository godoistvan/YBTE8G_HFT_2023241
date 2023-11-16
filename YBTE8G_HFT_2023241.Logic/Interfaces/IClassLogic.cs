using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Interfaces
{
    public interface IClassLogic
    {
        void Create(SportTeam classcreate);
        void Delete(int id);
        IEnumerable<SportTeam> ReadAll();
        SportTeam Read(int id);
        void Update(SportTeam classupdate);
    }
}
